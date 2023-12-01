using AppNetCore01.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppNetCore01.Web.ViewModels
{
    public class ProductoEditVm
    {
		public Producto Producto { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Marcas { get; set; }
    }
}
