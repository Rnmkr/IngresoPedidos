namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pedidos
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

        public int? FK_IDPedidoSucesor { get; set; }

        public int? FK_IDPedidoAnterior { get; set; }

        public virtual Modelos Modelos { get; set; }
    }
}
