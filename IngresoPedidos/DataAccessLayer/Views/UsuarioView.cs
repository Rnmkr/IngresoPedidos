namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuarioView")]
    public partial class UsuarioView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDUsuario { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string LegajoUsuario { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string NombreUsuario { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(25)]
        public string ApellidoUsuario { get; set; }

        [StringLength(48)]
        public string HashedPassword { get; set; }

        [StringLength(48)]
        public string HashedRFID { get; set; }
    }
}
