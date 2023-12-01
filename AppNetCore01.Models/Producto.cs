using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNetCore01.Models
{
    public class Producto
    {
    
        [Key]
        public int idProducto { get; set; }
         
        [StringLength(10)]
        public string codigo { get; set; }
        [Required]
        [StringLength(100)]
        public string descripcion { get; set; }
        [Required]
        [ForeignKey("Marca")]
        [DisplayName("Marca")]
        public int idMarca { get; set; }
        [ValidateNever]
        public Marca Marca { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Marcas { get; set; }
    }
}
