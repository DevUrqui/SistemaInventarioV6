using Microsoft.AspNetCore.Mvc;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;

namespace SistemaInventarioV6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BodegaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public BodegaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Bodega bodega = new Bodega();

            if(id == null)
            {
                //Crear una nueva bodega
                bodega.Estado = true;
                return View(bodega);
            }
            //Actualizar Bodega
            bodega = await _unidadTrabajo.Bodega.Obtener(id.GetValueOrDefault());
            if(bodega == null) 
            {
                return NotFound();
            }

            return View(bodega);
        }

        #region API

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Bodega.ObtenerTodos();

            return Json(new {data = todos });
        }
        #endregion
    }
}
