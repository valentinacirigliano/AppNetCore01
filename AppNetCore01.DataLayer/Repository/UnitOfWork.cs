using AppNetCore01.DataLayer.Data;
using AppNetCore01.DataLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNetCore01.DataLayer.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Marcas = new MarcaRepository(_db);
            Productos = new ProductoRepository(_db);
        }

        public IProductoRepository Productos { get; private set; }
        public IMarcaRepository Marcas { get; private set; }
        public void BeginTransaction()
        {
            _db.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _db.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _db.Database.RollbackTransaction();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
