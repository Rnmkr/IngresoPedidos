using System.Threading;
using System.Windows;
using IngresoPedidos.Views;
using IngresoPedidos.Models;
using System;

namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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