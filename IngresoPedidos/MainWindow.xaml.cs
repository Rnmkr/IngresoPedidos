using System.Windows;
using IngresoPedidos.DataAccessLayer;
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

            DBContext cb = new DBContext();
            StaticData.MainList = cb.PedidoView.Take(15).ToList();
            dgPedidos.ItemsSource = StaticData.MainList;
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
            FormularioPedidoWindow fpv = new FormularioPedidoWindow();
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
            CambiarContraseñaWindow ccw = new CambiarContraseñaWindow(true, StaticData.Usuario);
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
            PedidoView pedidoSeleccionado = (PedidoView)dgPedidos.SelectedItem;
            FormularioPedidoWindow fpv = new FormularioPedidoWindow(pedidoSeleccionado);
            fpv.Owner = this;
            fpv.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AgregarObservacion ao = new AgregarObservacion();
            ao.Owner = this;
            ao.ShowDialog();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var pedidoSeleccionado = dgPedidos.SelectedItem as PedidoView;
            var pedidoAnterior = StaticData.MainList.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoAnterior).SingleOrDefault();

            if (pedidoAnterior == null)
            {
                pedidoAnterior = StaticData.context.PedidoView.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoAnterior).SingleOrDefault();
                StaticData.MainList.Add(pedidoAnterior);
                dgPedidos.ItemsSource = null;
                dgPedidos.ItemsSource = StaticData.MainList;
                dgPedidos.SelectedItem = pedidoAnterior;
                dgPedidos.UpdateLayout();
                dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
            }
            else
            {
                dgPedidos.SelectedItem = pedidoAnterior;
                dgPedidos.UpdateLayout();
                dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
            }
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            var pedidoSeleccionado = dgPedidos.SelectedItem as PedidoView;
            var pedidoSucesor = StaticData.MainList.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoSucesor).SingleOrDefault();

            if (pedidoSucesor == null)
            {
                pedidoSucesor = StaticData.context.PedidoView.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoSucesor).SingleOrDefault();
                StaticData.MainList.Add(pedidoSucesor);
                dgPedidos.ItemsSource = null;
                dgPedidos.ItemsSource = StaticData.MainList;
                dgPedidos.SelectedItem = pedidoSucesor;
                dgPedidos.UpdateLayout();
                dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
            }
            else
            {
                dgPedidos.SelectedItem = pedidoSucesor;
                dgPedidos.UpdateLayout();
                dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
            }
        }
    }
}