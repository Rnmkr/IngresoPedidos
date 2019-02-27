namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermisoView")]
    public partial class PermisoView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_IDUsuario { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string NombreAplicacion { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string NombrePermiso { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool EstadoPermiso { get; set; }
    }
}
