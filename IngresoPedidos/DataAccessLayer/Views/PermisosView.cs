namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermisosView")]
    public partial class PermisosView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_IDUsuario { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string NombrePermiso { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool EstadoPermiso { get; set; }
    }
}
