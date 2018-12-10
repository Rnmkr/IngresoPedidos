using System;
using System.Collections.ObjectModel;

namespace IngresoPedidos.Models
{
    public class Pedido
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

        public Pedido()
        {

        }

        public Pedido(string pedido, string modelo, string producto, string articulo, int cantidad, DateTime fechaIngreso, string estado, DateTime? fechaEstado, string numeroReproceso)
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

    public class PedidoCollection : ObservableCollection<Pedido>
    {

    }
}
