using System.Windows;
using IngresoPedidos.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using IngresoPedidos.Helpers;

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

        //private void Button_Click_6(object sender, RoutedEventArgs e)
        //{
        //    MessageBoxResult exitApp = MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //    if (exitApp == MessageBoxResult.Yes)
        //    {
        //        Application.Current.Shutdown();
        //    }
        //}

        private void btnNuevoPedido_Click(object sender, RoutedEventArgs e)
        {
            FormularioPedido fpv = new FormularioPedido();
            fpv.Owner = this;
            fpv.ShowDialog();
        }

        private void btnBuscarPedido_Click(object sender, RoutedEventArgs e)
        {
            BusquedaWindow bw = new BusquedaWindow();
            bw.Owner = this;
            bw.ShowDialog();
        }

        private void btnCambiarContraseña_Click(object sender, RoutedEventArgs e)
        {
            CambiarContraseñaWindow ccw = new CambiarContraseñaWindow("925");
            ccw.Owner = this;
            ccw.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            ProcesandoWindow ccw = new ProcesandoWindow();
            ccw.Owner = this;
            ccw.ShowDialog();
        }

        private void btnFiltrarLista_Click(object sender, RoutedEventArgs e)
        {
            FiltroListaWindow flw = new FiltroListaWindow();
            flw.Owner = this;
            flw.ShowDialog();
        }

        private void ctxmnuEditar_Click(object sender, RoutedEventArgs e)
        {
            PedidosView pedidoSeleccionado = (PedidosView)dgPedidos.SelectedItem;
            FormularioPedido fpv = new FormularioPedido(pedidoSeleccionado);
            fpv.Owner = this;
            fpv.ShowDialog();
        }
    }
}