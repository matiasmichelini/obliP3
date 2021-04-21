using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    
    public class InversorModel : SolicitanteModel
    {
        [Required]
        public decimal PrestamoMaximo { get; set; }
        [Required]
        public string Descripcion { get; set; }

    }
}