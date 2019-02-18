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
            lblArticulo.Content = pedido.NumeroArticulo;
            lblModelo.Content = pedido.NombreModelo;
            lblProducto.Content = pedido.NombreProducto;
            lblCantidad.Content = pedido.CantidadEquipos;
            lblEstado.Content = pedido.NombreEstado;
            lblIngreso.Content = "INGRESADO " + pedido.FechaIngreso;
            lblEstado.Content = pedido.NombreEstado + " " + pedido.FechaEstado;
        }

        private void BtnSeleccionar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
