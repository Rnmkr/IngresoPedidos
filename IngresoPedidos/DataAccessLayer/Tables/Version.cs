namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Version")]
    public partial class Version
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_IDComponente { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string VersionComponente { get; set; }

        public virtual Componente Componente { get; set; }
    }
}
