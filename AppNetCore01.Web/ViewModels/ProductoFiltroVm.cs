using AppNetCore01.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppNetCore01.Web.ViewModels
{
    public class ProductoFiltroVm
    {
        public IEnumerable<Producto> Productos { get; set; }
        public IEnumerable<SelectListItem> Marcas { get; set; }
        public int? MarcaFiltro { get; set; }
    }
}
