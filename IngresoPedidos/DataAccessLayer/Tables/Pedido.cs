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
        [Key]
        public int IDPedido { get; set; }

        [Required]
        [StringLength(12)]
        public string NumeroPedido { get; set; }

        [Required]
        [StringLength(10)]
        public string NumeroArticulo { get; set; }

        public int FK_IDModelo { get; set; }

        public int CantidadEquipos { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaIngreso { get; set; }

        public int? FK_IDEstadoPedido { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaEstado { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual ReprocesoPedidos ReprocesoPedidos { get; set; }
    }
}
