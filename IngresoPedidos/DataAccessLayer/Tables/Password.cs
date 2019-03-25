namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Password")]
    public partial class Password
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_IDUsuario { get; set; }

        [StringLength(48)]
        public string HashedRFID { get; set; }

        [StringLength(48)]
        public string HashedPassword { get; set; }

        [StringLength(24)]
        public string HashSalt { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
