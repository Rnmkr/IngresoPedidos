using System;
using System.Collections.Generic;
using System.Linq;
using IngresoPedidos.DataAccessLayer;

namespace IngresoPedidos.Models
{
    public class PedidoView
    {
        public string NumeroPedido { get; set; }
        public string NombreModelo { get; set; }
        public string NombreProducto { get; set; }
        public string Articulo { get; set; }
        public int CantidadEquipos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string EstadoPedido { get; set; }
        public DateTime? FechaEstado { get; set; }
        public string NumeroReproceso { get; set; }

        public PedidoView()
        {

        }

        public PedidoView(string pedido, string modelo, string producto, string articulo, int cantidad, DateTime fechaIngreso, string estado, DateTime? fechaEstado, string numeroReproceso)
        {
            NumeroPedido = pedido;
            NombreModelo = modelo;
            NombreProducto = producto;
            Articulo = articulo;
            CantidadEquipos = cantidad;
            FechaIngreso = fechaIngreso;
            EstadoPedido = estado;
            FechaEstado = fechaEstado;
            NumeroReproceso = numeroReproceso;
        }
    }

    public class PedidosViewRepository
    {
        private List<PedidosView> _pedidosView;

        public PedidosViewRepository()
        {
             DbContext db = new DbContext();
            _pedidosView = db.PedidosView.Select(s => s).ToList();
        }

        public List<PedidosView> GetPedidosView()
        {
            return _pedidosView;
        }

        public void UpdatePedidoView(PedidosView SelectedCustomer)
        {
            //PedidoView customerToChange = .Single(s => s.CustomerID == SelectedCustomer.CustomerID);
            //customerToChange = SelectedCustomer;
        }
    }
}
