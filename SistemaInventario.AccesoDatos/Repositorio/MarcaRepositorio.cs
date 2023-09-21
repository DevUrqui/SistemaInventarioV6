using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using SistemaInventarioV6.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class MarcaRepositorio : Repositorio<Marca>, IMarcaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public MarcaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Marca marca)
        {
            var categoriaBD = _db.Marcas.FirstOrDefault(b => b.Id == marca.Id);
            if(categoriaBD != null)
            {
                categoriaBD.Nombre = marca.Nombre;
                categoriaBD.Descripcion = marca.Descripcion;
                categoriaBD.Estado = marca.Estado;
                _db.SaveChanges();
            }
        }
    }
}
