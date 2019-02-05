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
            tbKeyword.GotFocus += RemovePlaceholder;
            tbKeyword.LostFocus += AddPlaceholder;

            List<string> campos = new List<string> { "PEDIDO", "MODELO", "PRODUCTO", "ARTICULO", "CANTIDAD", "ESTADO", "SUCESOR", "ANTERIOR" };
            List<string> camposfecha = new List<string> { "INGRESO", "ESTADO" };

            cbCampo.ItemsSource = campos;
            cbCampoFecha.ItemsSource = camposfecha;
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbKeyword.Text))
            {
                tbKeyword.Foreground = System.Windows.Media.Brushes.Gray;
                tbKeyword.Text = "Buscar...";
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (tbKeyword.Text == "Buscar...")
            {
                tbKeyword.Foreground = System.Windows.Media.Brushes.Black;
                tbKeyword.Text = "";
            }
        }

        private void TbKeyword_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbKeyword.Text))
            {
                return;
            }

            if (e.Key == System.Windows.Input.Key.Enter)
            {
                BuscarRegistro();
            }
        }

        private void BuscarRegistro()
        {
            string keyword = tbKeyword.Text;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return;
            }

            if (keyword == "Buscar...")
            {
                return;
            }


            Buscador busqueda = new Buscador(StaticData.context);
            string campo = cbCampo.SelectedValue.ToString();
            string campofecha = cbCampoFecha.SelectedValue.ToString();
            DateTime fechainicio = dpInicial.SelectedDate ?? DateTime.Now;
            DateTime fechafinal= dpFinal.SelectedDate ?? DateTime.Now;
            //MessageBox.Show(keyword + campo + campofecha + fechainicio + fechafinal );
            //return;
            StaticData.SearchList = busqueda.ObtenerPedidos(keyword, campo, campofecha, fechainicio, fechafinal);
            dgPedidos.ItemsSource = null;
            //cb.Filtros.SelectedValue = "BUSQUEDA";
            //ahi ya deberia poner el source en lista-busqueda solo...
            dgPedidos.ItemsSource = StaticData.SearchList.OrderByDescending(o => o.IDPedido);
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
            FormularioPedido fpv = new FormularioPedido();
            fpv.Owner = this;
            fpv.Show();
        }

        private void ctxmnuEditar_Click(object sender, RoutedEventArgs e)
        {
            PedidosView pedidoSeleccionado = (PedidosView)dgPedidos.SelectedItem;
            FormularioPedido fpv = new FormularioPedido(pedidoSeleccionado);
            fpv.Owner = this;
            fpv.Show();
        }

        private void BtnBuscarPedido_Click(object sender, RoutedEventArgs e)
        {

            BuscarRegistro();

        }

        private void btnCambiarContraseña_Click(object sender, RoutedEventArgs e)
        {
            CambiarContraseñaWindow ccw = new CambiarContraseñaWindow("925");
            ccw.Owner = this;
            ccw.Show();
        }
    }
}