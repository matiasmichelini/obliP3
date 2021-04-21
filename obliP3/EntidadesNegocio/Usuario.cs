
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
    [Table("Usuarios")]
	public abstract class Usuario 
	{
        [Key]
		public string Ci{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "El largo debe ser mínimo 5")]
        public string Password { get; set; }

        [Required]
        public string TipoUsuario { get; set; }



        public bool Validar()
        {
            //TODO arreglar este
            return true;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} ",Ci, Password, TipoUsuario);
        }
    }

}

