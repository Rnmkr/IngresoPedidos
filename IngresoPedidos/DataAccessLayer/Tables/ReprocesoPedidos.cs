namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReprocesoPedidos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_IDPedido { get; set; }

        public int? FK_IDPedidoAnterior { get; set; }

        public int? FK_IDPedidoSucesor { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
