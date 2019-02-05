namespace IngresoPedidos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Permisos_Usuarios = new HashSet<Permisos_Usuarios>();
        }

        [Key]
        public int IDUsuario { get; set; }

        [Required]
        [StringLength(6)]
        public string LegajoUsuario { get; set; }

        [Required]
        [StringLength(25)]
        public string ApellidoUsuario { get; set; }

        [Required]
        [StringLength(25)]
        public string NombreUsuario { get; set; }

        [StringLength(48)]
        public string HashedRFID { get; set; }

        [StringLength(48)]
        public string HashedPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permisos_Usuarios> Permisos_Usuarios { get; set; }
    }
}
