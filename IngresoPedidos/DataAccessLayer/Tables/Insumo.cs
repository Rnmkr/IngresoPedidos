namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Insumo")]
    public partial class Insumo
    {
        [Key]
        public int IDInsumo { get; set; }

        [Required]
        [StringLength(25)]
        public string DescripcionInsumo { get; set; }

        [Required]
        [StringLength(3)]
        public string CoordenadaUbicacionInsumo { get; set; }

        public int Stock { get; set; }

        public int CantidadCritica { get; set; }
    }
}
