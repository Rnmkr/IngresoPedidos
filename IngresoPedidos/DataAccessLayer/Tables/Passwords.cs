namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Passwords
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_IDUsuario { get; set; }

        [StringLength(48)]
        public string HashedRFID { get; set; }

        [Required]
        [StringLength(48)]
        public string HashedPassword { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
