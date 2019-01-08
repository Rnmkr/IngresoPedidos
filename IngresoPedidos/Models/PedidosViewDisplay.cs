namespace IngresoPedidos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidosViewDisplay")]
    public partial class PedidosViewDisplay
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string Pedido { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string Modelo { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cantidad { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "smalldatetime")]
        public DateTime Ingreso { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string Estado { get; set; }
    }
}
