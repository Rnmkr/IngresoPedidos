namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Observacion")]
    public partial class Observacion
    {
        [Key]
        public int FK_IDAutorizacion { get; set; }

        [Required]
        [StringLength(60)]
        public string ObservacionAutorizacion { get; set; }

        public virtual Autorizacion Autorizacion { get; set; }
    }
}
