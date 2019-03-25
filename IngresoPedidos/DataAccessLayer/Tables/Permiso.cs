namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permiso")]
    public partial class Permiso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Permiso()
        {
            PermisoUsuario = new HashSet<PermisoUsuario>();
        }

        [Key]
        public short IDPermiso { get; set; }

        public byte FK_IDAplicacion { get; set; }

        [Required]
        [StringLength(50)]
        public string NombrePermiso { get; set; }

        public virtual Aplicacion Aplicacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermisoUsuario> PermisoUsuario { get; set; }
    }
}
