namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reparacion")]
    public partial class Reparacion
    {
        [Key]
        public int IDReparacion { get; set; }

        public int NumeroReparacion { get; set; }

        [Required]
        [StringLength(11)]
        public string NumeroSerieEquipo { get; set; }

        public int FK_IDComponente { get; set; }

        public int FK_IDFalla { get; set; }

        public int FK_IDUsuario { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaReparacion { get; set; }

        public bool EstadoReparacion { get; set; }

        public virtual Componente Componente { get; set; }

        public virtual Falla Falla { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
