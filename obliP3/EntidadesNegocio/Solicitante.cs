using Dominio.EntidadesNegocio;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
    [Table("Solicitantes")]
    public class Solicitante : Usuario
	{
        [Required]
        public string Nombre{ get; set; }
        [Required]
        public string Apellido{ get; set; }
        [Required]
        public DateTime FechaNac{ get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"([0]{1})([9]{1})([1-9]{1})([0-9]{6})", ErrorMessage = "EL numero no es valido")]
        public string Celular{ get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} ingresó el  {2}  y su celular es {3} ",
                Nombre,Apellido, FechaNac.ToShortDateString(), Celular);
        }
        
        
    }

}

