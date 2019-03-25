namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Componente")]
    public partial class Componente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Componente()
        {
            Autorizacion = new HashSet<Autorizacion>();
            Reparacion = new HashSet<Reparacion>();
            Version = new HashSet<Version>();
            Modelo = new HashSet<Modelo>();
            Orden = new HashSet<Orden>();
        }

        [Key]
        public int IDComponente { get; set; }

        public int FK_IDCategoria { get; set; }

        [Required]
        [StringLength(10)]
        public string ArticuloComponente { get; set; }

        [Required]
        [StringLength(25)]
        public string NombreComponente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autorizacion> Autorizacion { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Despacho Despacho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reparacion> Reparacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Version> Version { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Modelo> Modelo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orden> Orden { get; set; }
    }
}
