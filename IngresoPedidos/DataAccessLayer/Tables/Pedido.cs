namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pedido")]
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            Autorizacion = new HashSet<Autorizacion>();
        }

        [Key]
        public int IDPedido { get; set; }

        [Required]
        [StringLength(12)]
        public string NumeroPedido { get; set; }

        [Required]
        [StringLength(10)]
        public string NumeroArticulo { get; set; }

        public int FK_IDModelo { get; set; }

        public short CantidadEquipos { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaIngreso { get; set; }

        public byte? FK_IDEstadoPedido { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaEstado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autorizacion> Autorizacion { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual ReprocesoPedido ReprocesoPedido { get; set; }
    }
}
