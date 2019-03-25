namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orden")]
    public partial class Orden
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orden()
        {
            Componente = new HashSet<Componente>();
        }

        [Key]
        public int IDOrden { get; set; }

        [Required]
        [StringLength(10)]
        public string CodigoOrden { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Componente> Componente { get; set; }
    }
}
