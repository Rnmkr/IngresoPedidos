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

                case "INGRESADO":
                    try
                    {
                        return db.PedidosView.Where(w => w.EstadoPedido == "INGRESADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();
                    }
                    catch (Exception)
                    {

                        throw;
                    }


                case "COMPLETO":
                    return db.PedidosView.Where(w => w.EstadoPedido == "COMPLETO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

                case "INCOMPLETO":
                    return db.PedidosView.Where(w => w.EstadoPedido == "INCOMPLETO").OrderByDescending(o => o.IDPedido).OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

                case "AUTORIZADO":
                    return db.PedidosView.Where(w => w.EstadoPedido == "AUTORIZADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

                case "PRODUCCION":
                    return db.PedidosView.Where(w => w.EstadoPedido == "PRODUCCION").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

                case "PAUSADO":
                    return db.PedidosView.Where(w => w.EstadoPedido == "PAUSADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

                case "CANCELADO":
                    return db.PedidosView.Where(w => w.EstadoPedido == "CANCELADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

                case "FINALIZADO":
                    return db.PedidosView.Where(w => w.EstadoPedido == "FINALIZADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

                case "REPROCESADO":
                    return db.PedidosView.Where(w => w.EstadoPedido == "REPROCESADO").OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

                case "DESPACHADO":
                    return db.PedidosView.Where(w => w.EstadoPedido == "DESPACHADO").OrderByDescending(o => o.IDPedido).Take(10000).ToList();

                case "SUCESORES":
                    return db.PedidosView.Where(w => w.NumeroOriginal != null).OrderByDescending(o => o.IDPedido).Select(s => s).ToList();

                case "PERSONALIZADA":
                    return null;

                case "BUSQUEDA":
                    return null;

                default:
                    return db.PedidosView.OrderByDescending(o => o.IDPedido).Take(10000).ToList();
            }
        }
    }
}
