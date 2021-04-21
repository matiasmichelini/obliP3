
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.EntidadesNegocio;

namespace Dominio.EntidadesNegocio
{
    [Table("ProyectosAnalizados")]
    public class ProyectoAnalizado
	{
		public int Id{ get; set; }

		public DateTime Fecha{ get; set; }

		public decimal MontoTotal{ get; set; }

		public decimal CuotaTotal{ get; set; }

        public decimal TasaInteres{ get; set; }

		public int Puntaje{ get; set; }

		public string Estado{ get; set; }


        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; } //conseguir que sea FK
        public virtual Proyecto Proyecto{ get; set; }

        [ForeignKey("Admin")]
        public string AdminCi { get; set; } //conseguir que sea FK
        public virtual Admin Admin{ get; set; }

        public bool Validar()
        {
            return true;
        }
	}

}

