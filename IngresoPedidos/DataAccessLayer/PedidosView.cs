namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidosView")]
    public partial class PedidosView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string NumeroPedido { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string NombreModelo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string NombreProducto { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string Articulo { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CantidadEquipos { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "smalldatetime")]
        public DateTime FechaIngreso { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(10)]
        public string EstadoPedido { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaEstado { get; set; }

        [StringLength(12)]
        public string NumeroReproceso { get; set; }
    }
}
