using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class SolicitanteModel : UsuarioModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public DateTime FechaNac { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"([0]{1})([9]{1})([1-9]{1})([0-9]{6})", ErrorMessage = "EL numero no es valido")]
        public string Celular { get; set; }
    }
}