using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

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

        private void DataGridPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPedidos.SelectedIndex == -1)
            {
                DataGridPedidos.SelectedIndex = -1;
                DataGridPedidos.ScrollIntoView(DataGridPedidos.Items[DataGridPedidos.Items.Count - 1]);
            }
        }
    }
}