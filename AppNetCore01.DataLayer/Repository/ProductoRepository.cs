using AppNetCore01.DataLayer.Data;
using AppNetCore01.DataLayer.Repository.Interfaces;
using AppNetCore01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNetCore01.DataLayer.Repository
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool Exists(Producto Producto)
        {
            if (Producto.idProducto == 0)
            {
                return _db.Productos.Any(c => c.descripcion == Producto.descripcion);
            }
            return _db.Productos.Any(c => c.descripcion == Producto.descripcion && c.idProducto != Producto.idProducto);
        }


        public void Update(Producto Producto)
        {
            _db.Productos.Update(Producto);
        }
    }
}
