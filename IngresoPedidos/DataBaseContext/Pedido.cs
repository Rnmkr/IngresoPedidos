namespace IngresoPedidos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pedido
    {
        [Key]
        public int IDPedido { get; set; }

        [Required]
        [StringLength(12)]
        public string NumeroPedido { get; set; }

        [Required]
        [StringLength(10)]
        public string Articulo { get; set; }

        public int FK_IDModelo { get; set; }

        public int CantidadEquipos { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaIngreso { get; set; }

        [Required]
        [StringLength(11)]
        public string EstadoPedido { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaEstado { get; set; }

        public int? FK_IDPedidoReproceso { get; set; }

        public int? FK_IDPedidoOriginal { get; set; }

        public virtual Modelo Modelos { get; set; }
    }
}
