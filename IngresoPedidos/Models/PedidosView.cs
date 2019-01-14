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
        private List<PedidosView> _pedidosViewList;

        public PedidosViewRepository()
        {
        }



        public List<PedidosView> GetPedidosView(string filter)
        {
            DataBaseContext db = new DataBaseContext();

            switch (filter)
            {
                case "INGRESADO":
                    _pedidosViewList = db.PedidosView.Where(W => W.EstadoPedido == "INGRESADO").Select(s => s).ToList();
                    break;

                case "DESPACHADO":
                    _pedidosViewList = db.PedidosView.Where(W => W.EstadoPedido == "DESPACHADO").Select(s => s).ToList();
                    break;

                case "DISPONIBLE":
                    _pedidosViewList = db.PedidosView.Where(W => W.EstadoPedido == "DISPONIBLE").Select(s => s).ToList();
                    break;

                case "PAUSADO":
                    _pedidosViewList = db.PedidosView.Where(W => W.EstadoPedido == "PAUSADO").Select(s => s).ToList();
                    break;

                case "AUTORIZADO":
                    _pedidosViewList = db.PedidosView.Where(W => W.EstadoPedido == "AUTORIZADO").Select(s => s).ToList();
                    break;

                case "INCOMPLETO":
                    _pedidosViewList = db.PedidosView.Where(W => W.EstadoPedido == "INCOMPLETO").Select(s => s).ToList();
                    break;

                case "COMPLETO":
                    _pedidosViewList = db.PedidosView.Where(W => W.EstadoPedido == "COMPLETO").Select(s => s).ToList();
                    break;

                case "REPROCESADO":
                    _pedidosViewList = db.PedidosView.Where(W => W.EstadoPedido == "REPROCESADO").Select(s => s).ToList();
                    break;

                case "TODOS":
                    _pedidosViewList = db.PedidosView.Where(W => W.EstadoPedido == "TODOS").Select(s => s).ToList();
                    break;


                default:
                    _pedidosViewList = db.PedidosView.Where(W => W.EstadoPedido == "INGRESADO").Select(s => s).ToList();
                    break;
            }
            return _pedidosViewList;
        }
    }
}
