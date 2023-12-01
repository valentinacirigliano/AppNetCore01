using AppNetCore01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNetCore01.DataLayer.Repository.Interfaces
{
    public interface IProductoRepository: IRepository<Producto>
    {
        void Update(Producto producto);
        bool Exists(Producto producto);
    }
}
