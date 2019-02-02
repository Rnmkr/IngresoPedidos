using System.Windows;
using IngresoPedidos.Views;

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
            //cbFiltros.SelectedIndex = 6;
        }

        //private void DataGridPedidos_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (DataGridPedidos.Items.Count > 0)
        //    {
        //        var border = VisualTreeHelper.GetChild(DataGridPedidos, 0) as Decorator;
        //        if (border != null)
        //        {
        //            var scroll = border.Child as ScrollViewer;
        //            if (scroll != null) scroll.ScrollToEnd();
        //        }
        //        DataGridPedidos.SelectedIndex = -1;
        //        DataGridPedidos.SelectedItem = null;
        //    }
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ImagenView iv = new ImagenView();
            iv.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BusquedaView bv = new BusquedaView();
            bv.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MovimientosView mv = new MovimientosView();
            mv.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FormularioPedidoView np = new FormularioPedidoView();
            np.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObservacionView ov = new ObservacionView();
            ov.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FormularioPedidoView ev = new FormularioPedidoView();
            ev.ShowDialog();
        }
    }
}