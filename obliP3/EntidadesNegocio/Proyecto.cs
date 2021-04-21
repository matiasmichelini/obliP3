
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.EntidadesNegocio;

namespace Dominio.EntidadesNegocio
{
    [Table("Proyectos")]
	public abstract class Proyecto 
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id{ get; set; }

		public string Titulo{ get; set; }

        public string Descripcion{ get; set; }

		public decimal MontoSolicitado{ get; set; }

		public int CantCuotas{ get; set; }

		public string Imagen{ get; set; }

		public DateTime Fecha{ get; set; }
        [ForeignKey("Solicitante")]
        public string SolicitanteCi { get; set; } //conseguir que sea FK
        public virtual Solicitante Solicitante { get; set; }

        //public Solicitante Solicitante { get; set; }

        public bool Validar()
        {
            return true;
        }


    }

}

