using Dominio.EntidadesNegocio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
    [Table("Personales")]
    public class Personal : Proyecto
	{
		public string ExpProy{ get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }

    }

}

