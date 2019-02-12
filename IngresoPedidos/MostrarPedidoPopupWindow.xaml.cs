using IngresoPedidos.DataAccessLayer;
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
    /// Interaction logic for MostrarPedidoPopUp.xaml
    /// </summary>
    public partial class MostrarPedidoPopupWindow : Window
    {
        public MostrarPedidoPopupWindow(string tipo, PedidoView pedidoSeleccionado, PedidoView pedido)
        {
            InitializeComponent();
            dgPedidoPopup.Items.Add(pedido);
            Title = "Pedido " + tipo + " a " + pedidoSeleccionado.NumeroPedido;
        }
    }
}
