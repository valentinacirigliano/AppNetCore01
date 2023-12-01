using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNetCore01.Models
{
    public class Marca
    {
        [Key]
        public int idMarca { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "The field {0} must be between {2} y {1} characters", MinimumLength = 5)]
        public string nombre { get; set; }
    }
}
