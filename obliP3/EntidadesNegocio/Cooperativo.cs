using Dominio.EntidadesNegocio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
    [Table("Cooperativos")]
    public class Cooperativo : Proyecto
	{
		public int Integrantes{ get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
        

    }

}

