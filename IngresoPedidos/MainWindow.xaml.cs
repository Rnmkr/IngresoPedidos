using System.Threading;
using System.Windows;
using IngresoPedidos.Views;
using IngresoPedidos.Models;

namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ImagenView iv = new ImagenView();
            iv.Owner = this;
            iv.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BusquedaView bv = new BusquedaView();
            bv.Owner = this;
            bv.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EventosView ev = new EventosView();
            ev.Owner = this;
            ev.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FormularioPedidoView np = new FormularioPedidoView();
            np.Owner = this;
            np.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CambiarContraseñaView ev = new CambiarContraseñaView();
            ev.Owner = this;
            ev.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginView ev = new LoginView();
            ev.Owner = this;
            dgPedidos.ItemsSource = null;
            
            ev.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MessageBoxResult exitApp = MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (exitApp == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }

        private void btnNuevoPedido_Click(object sender, RoutedEventArgs e)
        {
            FormularioPedidoView fpv = new FormularioPedidoView();
            fpv.Owner = this;
            fpv.Show();
        }

        private void ctxmnuEditar_Click(object sender, RoutedEventArgs e)
        {
            PedidoView pedidoSeleccionado = (PedidoView)dgPedidos.SelectedItem;
            FormularioPedidoView fpv = new FormularioPedidoView(pedidoSeleccionado);
            fpv.Owner = this;
            fpv.Show();
        }
    }
}