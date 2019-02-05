using System;
using System.Windows;
using IngresoPedidos.Models;
namespace IngresoPedidos.Views
{
    /// <summary>
    /// Interaction logic for NuevoPedido.xaml
    /// </summary>
    public partial class FormularioPedidoView : Window
    {
        PedidoView nuevoPedido;
        PedidoView viejoPedido;

        public FormularioPedidoView()
        {
            InitializeComponent();
            this.Title = "NUEVO PEDIDO";
            cbEstado.SelectedIndex = 0;
            cbEstado.IsEnabled = false;
        }

        public FormularioPedidoView(PedidoView p)
        {
            InitializeComponent();
            this.Title = "EDITAR PEDIDO";
            PedidoView pedidoSeleccionado = p;
            tbPedido.Text = pedidoSeleccionado.NumeroPedido;
            tbPedido.IsEnabled = false;
            cbModelo.SelectedValue = pedidoSeleccionado.NombreModelo;
            cbModelo.SelectedValue = pedidoSeleccionado.NombreProducto;
            tbArticulo.Text = pedidoSeleccionado.Articulo;
            tbCantidad.Text = pedidoSeleccionado.CantidadEquipos.ToString();
            cbEstado.SelectedValue = pedidoSeleccionado.EstadoPedido;
            tbAnterior.Text = pedidoSeleccionado.NumeroReproceso;
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
