namespace IngresoPedidos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("PedidosView")]
    public partial class PedidosView
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
        [StringLength(25)]
        public string NombreModelo { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(25)]
        public string NombreProducto { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string Articulo { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CantidadEquipos { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "smalldatetime")]
        public DateTime FechaIngreso { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(11)]
        public string EstadoPedido { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaEstado { get; set; }

        [StringLength(12)]
        public string NumeroReproceso { get; set; }

        [StringLength(12)]
        public string NumeroOriginal { get; set; }
    }

    public class PedidosViewRepository
    {
        public PedidosViewRepository()
        {

        }

        public List<PedidosView> GetPedidosView(string filtro)
        {
            DataBaseContext db = new DataBaseContext();

            switch (filtro)
            {

                case "INGRESADOS":
                    return db.PedidosView.Where(w => w.EstadoPedido == "INGRESADO").Select(s => s).ToList();

                case "COMPLETOS":
                    return db.PedidosView.Where(w => w.EstadoPedido == "COMPLETO").Select(s => s).ToList();

                case "INCOMPLETOS":
                    return db.PedidosView.Where(W => W.EstadoPedido == "INCOMPLETO").Select(s => s).ToList();

                case "AUTORIZADOS":
                    return db.PedidosView.Where(W => W.EstadoPedido == "AUTORIZADO").Select(s => s).ToList();

                case "PRODUCCION":
                    return db.PedidosView.Where(W => W.EstadoPedido == "PRODUCCION").Select(s => s).ToList();

                case "PAUSADOS":
                    return db.PedidosView.Where(W => W.EstadoPedido == "PAUSADO").Select(s => s).ToList();

                case "CANCELADOS":
                    return db.PedidosView.Where(W => W.EstadoPedido == "CANCELADO").Select(s => s).ToList();

                case "REPROCESADOS":
                    return db.PedidosView.Where(W => W.EstadoPedido == "REPROCESADO").Select(s => s).ToList();

                case "DESPACHADOS":
                    return db.PedidosView.Where(W => W.EstadoPedido == "DESPACHADO").OrderByDescending(o => o.FechaIngreso).Take(10000).ToList();

                default:
                    return db.PedidosView.OrderByDescending(o => o.FechaIngreso).Take(20000).ToList();
            }
        }
    }
}
