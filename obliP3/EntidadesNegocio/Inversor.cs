using Dominio.EntidadesNegocio;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
    [Table("Inversores")]
    public class Inversor : Solicitante
	{
        [Required]
        public decimal PrestamoMaximo{ get; set; }
        [Required]
        public string Descripcion{ get; set; }

	}

}

