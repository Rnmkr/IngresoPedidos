namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Despacho")]
    public partial class Despacho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_IDItem { get; set; }

        public int Stock { get; set; }

        [Required]
        [StringLength(3)]
        public string CoordenadaUbicacion { get; set; }

        public int CantidadCritica { get; set; }

        public virtual Componente Componente { get; set; }
    }
}
