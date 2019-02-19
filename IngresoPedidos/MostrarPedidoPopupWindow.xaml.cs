using IngresoPedidos.DataAccessLayer;
using System.Windows;

namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for MostrarPedidoPopUp.xaml
    /// </summary>
    public partial class MostrarPedidoPopupWindow : Window
    {
        public MostrarPedidoPopupWindow(string tipo, PedidoView pedidoSeleccionado, PedidoView pedido)
        {
            InitializeComponent();
            Title = tipo + " DE " + pedidoSeleccionado.NumeroPedido;
            lblPedido.Content = pedido.NumeroPedido;
            lblDescripcion.Content = pedido.NumeroArticulo + " " + pedido.NombreProducto + " " + pedido.NombreModelo + " (x" + pedido.CantidadEquipos + ")";
            lblIngreso.Content = "INGRESADO " + pedido.FechaIngreso;
            lblEstado.Content = pedido.NombreEstado + " " + pedido.FechaEstado;
        }

        private void BtnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
