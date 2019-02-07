using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for RegistroE.xaml
    /// </summary>
    public partial class RegistroEventosWindow : Window
    {
        public RegistroEventosWindow()
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

