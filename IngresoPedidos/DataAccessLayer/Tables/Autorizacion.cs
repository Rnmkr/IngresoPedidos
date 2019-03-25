namespace IngresoPedidos.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Autorizacion")]
    public partial class Autorizacion
    {
        [Key]
        public int IDAutorizacion { get; set; }

        public int FK_IDPedido { get; set; }

        public int FK_IDComponente { get; set; }

        public int FK_IDFalla { get; set; }

        public int FK_IDUsuario { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaEmision { get; set; }

        public bool EstadoAutorizacion { get; set; }

        public virtual Componente Componente { get; set; }

        public virtual Falla Falla { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Observacion Observacion { get; set; }
    }
}
