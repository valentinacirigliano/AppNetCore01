using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNetCore01.DataLayer.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IProductoRepository Productos { get; }
        IMarcaRepository Marcas { get; }
        
        void Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
