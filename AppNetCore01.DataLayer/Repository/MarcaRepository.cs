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
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        private readonly ApplicationDbContext _db;
        public MarcaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool Exists(Marca Marca)
        {
            if (Marca.idMarca == 0)
            {
                return _db.Marcas.Any(c => c.nombre == Marca.nombre);
            }
            return _db.Marcas.Any(c => c.nombre == Marca.nombre && c.idMarca != Marca.idMarca);
        }


        public void Update(Marca Marca)
        {
            _db.Marcas.Update(Marca);
        }
    }
}
