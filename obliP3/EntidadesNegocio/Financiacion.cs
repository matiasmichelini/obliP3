using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
    [Table("Financiaciones")]
    public class Financiacion
	{
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProyectoAnalizado")]
        public int ProyectoAnalizadoId { get; set; } //conseguir que sea FK
        public ProyectoAnalizado ProyectoAnalizado { get; set; }
        
        public virtual ICollection<FinanciacionParcial> FinanciacionesParciales { get; set; }

        public DateTime Fecha { get; set; }

        public decimal TotalFinanciado { get; set; }

    }

}

