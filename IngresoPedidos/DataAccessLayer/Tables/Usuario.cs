namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Autorizacion = new HashSet<Autorizacion>();
            Reparacion = new HashSet<Reparacion>();
            PermisoUsuario = new HashSet<PermisoUsuario>();
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

        public bool? EstadoUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autorizacion> Autorizacion { get; set; }

        public virtual Password Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reparacion> Reparacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermisoUsuario> PermisoUsuario { get; set; }
    }
}
