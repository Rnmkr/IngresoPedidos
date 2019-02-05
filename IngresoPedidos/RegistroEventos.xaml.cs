using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace IngresoPedidos.Views
{
    /// <summary>
    /// Interaction logic for MovimientosView.xaml
    /// </summary>
    public partial class EventosView : Window
    {
        public EventosView()
        {
            InitializeComponent();

            List<string> ListaMovimientos = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"c:\test.txt");

            lines = lines.Skip(1).ToArray();
            for (int i = 0; i < lines.Length; i++)
            {
                ListaMovimientos.Add(lines[i]);
            }

            lbMovimientos.ItemsSource = ListaMovimientos;
        }

        private void LbMovimientos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //lbMovimientos.SelectedValue = null;
        }
    }
}
