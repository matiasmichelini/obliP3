using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
    [Table("FinanciacionesParciales")]
    public class FinanciacionParcial
    {
        [Key]
        public int Id { get; set; }

        public int MontoFinanaciado { get; set; }

        public DateTime Fecha { get; set; }

        [ForeignKey("Inversor")]
        public string InversorCi { get; set; } //conseguir que sea FK
        public virtual Inversor Inversor { get; set; }
    }
}