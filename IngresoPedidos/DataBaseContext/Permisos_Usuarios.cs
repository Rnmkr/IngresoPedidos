namespace IngresoPedidos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permisos-Usuarios")]
    public partial class Permisos_Usuarios
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
        public bool Valor { get; set; }

        public virtual Permiso Permisos { get; set; }

        public virtual Usuario Usuarios { get; set; }
    }
}
