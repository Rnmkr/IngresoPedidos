using System.Windows;
using IngresoPedidos.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using IngresoPedidos.Helpers;
using System.Windows.Input;
using System.Threading;
using static IngresoPedidos.SplashScreenCustom;

namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly RoutedCommand NuevoPedidoCommand = new RoutedCommand();

        //public static ISplashScreen splashScreen;
        //private ManualResetEvent ResetSplashCreated;
        //private Thread SplashThread;

        public MainWindow()
        {
            InitializeComponent();
            lblNombreUsuario.Content = StaticData.Usuario.ApellidoUsuario + " " + StaticData.Usuario.NombreUsuario;

            StaticData.FiltroSeleccionado = "INGRESADO";
            StaticData.ListaPrincipal = StaticData.DataBaseContext.PedidoView.Where(w => w.NombreEstado == StaticData.FiltroSeleccionado).Select(s => s).ToList();
            dgPedidos.ItemsSource = StaticData.ListaPrincipal;
        }

        private void NuevoPedidoCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            FormularioPedidoWindow fpv = new FormularioPedidoWindow();
            fpv.Owner = this;
            fpv.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult exitApp = MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (exitApp == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Open();//Implementation of open file");
        }
        private void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("SaveAs();//Implementation of saveAs");
        }

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
            dgPedidos.ItemsSource = null;
            dgPedidos.ItemsSource = StaticData.ListaPrincipal;
        }

        private void btnCambiarContraseña_Click(object sender, RoutedEventArgs e)
        {
            CambiarContraseñaWindow ccw = new CambiarContraseñaWindow();
            ccw.Owner = this;
            ccw.ShowDialog();
        }

        private void btnFiltrarLista_Click(object sender, RoutedEventArgs e)
        {
            FiltroListaWindow flw = new FiltroListaWindow();
            flw.Owner = this;
            flw.ShowDialog();
            dgPedidos.ItemsSource = null;
            dgPedidos.ItemsSource = StaticData.ListaPrincipal;
        }

        private void CtxmnuEditar_Click(object sender, RoutedEventArgs e)
        {
            PedidoView pedidoSeleccionado = (PedidoView)dgPedidos.SelectedItem;
            FormularioPedidoWindow fpv = new FormularioPedidoWindow(pedidoSeleccionado);
            fpv.Owner = this;
            fpv.ShowDialog();
            //sasa
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AgregarObservacion ao = new AgregarObservacion();
            ao.Owner = this;
            ao.ShowDialog();
        }

        private void HyperlinkAnterior_Click(object sender, RoutedEventArgs e)
        {
            var pedidoSeleccionado = dgPedidos.SelectedItem as PedidoView;
            var pedidoAnterior = StaticData.ListaPrincipal.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoAnterior).SingleOrDefault();

            if (pedidoAnterior == null)
            {
                pedidoAnterior = StaticData.DataBaseContext.PedidoView.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoAnterior).SingleOrDefault();
                StaticData.ListaPrincipal.Add(pedidoAnterior);
                dgPedidos.ItemsSource = null;
                dgPedidos.ItemsSource = StaticData.ListaPrincipal;
                dgPedidos.SelectedItem = pedidoAnterior;
                dgPedidos.UpdateLayout();
                dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
                dgPedidos.Focus();
            }
            else
            {
                dgPedidos.SelectedItem = pedidoAnterior;
                dgPedidos.UpdateLayout();
                dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
                dgPedidos.Focus();
            }
        }

        private void HyperlinkSucesor_Click(object sender, RoutedEventArgs e)
        {
            var pedidoSeleccionado = dgPedidos.SelectedItem as PedidoView;
            var pedidoSucesor = StaticData.ListaPrincipal.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoSucesor).SingleOrDefault();

            if (pedidoSucesor == null)
            {
                pedidoSucesor = StaticData.DataBaseContext.PedidoView.Where(w => w.NumeroPedido == pedidoSeleccionado.NumeroPedidoSucesor).SingleOrDefault();
                StaticData.ListaPrincipal.Add(pedidoSucesor);
                dgPedidos.ItemsSource = null;
                dgPedidos.ItemsSource = StaticData.ListaPrincipal;
                dgPedidos.SelectedItem = pedidoSucesor;
                dgPedidos.UpdateLayout();
                dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
                dgPedidos.Focus();
            }
            else
            {
                dgPedidos.SelectedItem = pedidoSucesor;
                dgPedidos.UpdateLayout();
                dgPedidos.ScrollIntoView(dgPedidos.SelectedItem);
                dgPedidos.Focus();
            }
        }

        private void OcultarMenu()
        {
            if (StaticData.FiltroSeleccionado == "PERSONALIZADA")
            {
                miAgregarPersonalizada.Visibility = Visibility.Collapsed;
                miAgregarPersonalizada.IsEnabled = false;
                miQuitarPersonalizada.Visibility = Visibility.Visible;
            }
            else
            {
                miQuitarPersonalizada.Visibility = Visibility.Collapsed;
                miQuitarPersonalizada.IsEnabled = false;
                miAgregarPersonalizada.Visibility = Visibility.Visible;
            }
        }
    }
}