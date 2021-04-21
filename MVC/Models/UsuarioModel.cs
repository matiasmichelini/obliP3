using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
   
    public abstract class UsuarioModel
    {
        [Key]
        public string Ci { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "El largo debe ser mínimo 5")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las passwords deben coincidir")]
        public string PasswordComparada { get; set; }


        [Required]
        public string TipoUsuario { get; set; }



        public bool Validar()
        {
            //TODO arreglar este
            return true;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} ", Ci, Password, TipoUsuario);
        }
    }
}