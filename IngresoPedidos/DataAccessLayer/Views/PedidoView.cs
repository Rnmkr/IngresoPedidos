namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidoView")]
    public partial class PedidoView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDPedido { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string NumeroPedido { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string NumeroArticulo { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(25)]
        public string NombreProducto { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(25)]
        public string NombreModelo { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CantidadEquipos { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "smalldatetime")]
        public DateTime FechaIngreso { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(11)]
        public string NombreEstado { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaEstado { get; set; }

        [StringLength(12)]
        public string NumeroPedidoAnterior { get; set; }

        [StringLength(12)]
        public string NumeroPedidoSucesor { get; set; }
    }
}
