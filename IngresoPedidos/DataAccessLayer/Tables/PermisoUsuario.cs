namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermisoUsuario")]
    public partial class PermisoUsuario
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_IDPermiso { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_IDUsuario { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool EstadoPermiso { get; set; }

        public virtual Permiso Permiso { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
