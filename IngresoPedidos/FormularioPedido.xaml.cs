using System;
using System.Windows;
using IngresoPedidos.DatabaseContext;

namespace IngresoPedidos
{
    public partial class FormularioPedido : Window
    {
        PedidosView nuevoPedido;
        PedidosView viejoPedido;

        public FormularioPedido()
        {
            InitializeComponent();
            this.Title = "NUEVO PEDIDO";
            cbEstado.SelectedIndex = 0;
            cbEstado.IsEnabled = false;
        }

        public FormularioPedido(PedidosView p)
        {
            InitializeComponent();
            this.Title = "EDITAR PEDIDO";
            PedidosView pedidoSeleccionado = p;
            tbPedido.Text = pedidoSeleccionado.NumeroPedido;
            tbPedido.IsEnabled = false;
            cbModelo.SelectedValue = pedidoSeleccionado.NombreModelo;
            cbModelo.SelectedValue = pedidoSeleccionado.NombreProducto;
            tbArticulo.Text = pedidoSeleccionado.Articulo;
            tbCantidad.Text = pedidoSeleccionado.CantidadEquipos.ToString();
            cbEstado.SelectedValue = pedidoSeleccionado.EstadoPedido;
            tbAnterior.Text = pedidoSeleccionado.PedidoAnterior;
            tbObservacion.Focus();

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ComprobarCampos())
            {
                MostrarCambios();
            }
        }

        private void MostrarCambios()
        {
            throw new NotImplementedException();
        }

        private bool ComprobarCampos()
        {
            throw new NotImplementedException();
        }
    }
}
