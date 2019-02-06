using System;
using System.Windows;
using System.Windows.Controls;
using IngresoPedidos.DatabaseContext;

namespace IngresoPedidos
{
    public partial class FormularioPedido : Window
    {
        PedidosView nuevoPedido;
        PedidosView viejoPedido;

        public FormularioPedido()
        {
            InitializeComponent();
            this.Title = "NUEVO PEDIDO";
            cbEstado.SelectedIndex = 0;
            cbEstado.IsEnabled = false;
            tbPedido.GotFocus += RemovePlaceholder;
            tbPedido.LostFocus += AddPlaceholder;
            tbArticulo.GotFocus += RemovePlaceholder;
            tbArticulo.LostFocus += AddPlaceholder;
            tbCantidad.GotFocus += RemovePlaceholder;
            tbCantidad.LostFocus += AddPlaceholder;
            tbAnterior.GotFocus += RemovePlaceholder;
            tbAnterior.LostFocus += AddPlaceholder;
        }

        public FormularioPedido(PedidosView p)
        {
            InitializeComponent();
            this.Title = "EDITAR PEDIDO";
            PedidosView pedidoSeleccionado = p;
            tbPedido.Text = pedidoSeleccionado.NumeroPedido;
            tbPedido.IsEnabled = false;
            cbModelo.SelectedValue = pedidoSeleccionado.NombreModelo;
            cbModelo.SelectedValue = pedidoSeleccionado.NombreProducto;
            tbArticulo.Text = pedidoSeleccionado.Articulo;
            tbCantidad.Text = pedidoSeleccionado.CantidadEquipos.ToString();
            cbEstado.SelectedValue = pedidoSeleccionado.EstadoPedido;
            tbAnterior.Text = pedidoSeleccionado.PedidoAnterior;
            tbObservacion.Focus();

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ComprobarCampos())
            {
                MostrarCambios();
            }
        }

        private void MostrarCambios()
        {
            throw new NotImplementedException();
        }

        private bool ComprobarCampos()
        {
            throw new NotImplementedException();
        }


        private void AddPlaceholder(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Foreground = System.Windows.Media.Brushes.Gray;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                switch (tb.Name)
                {
                    case "tbPedido":
                        tb.Text = "PEDIDO";
                        break;

                    case "tbArticulo":
                        tb.Text = "ARTICULO";
                        break;

                    case "tbCantidad":
                        tb.Text = "CANTIDAD";
                        break;

                    case "tbAnterior":
                        tb.Text = "ANTERIOR";
                        break;

                    default:
                        break;
                }
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Foreground = System.Windows.Media.Brushes.Black;

            switch (tb.Name)
            {
                case "tbPedido":
                    if (tb.Text == "PEDIDO")
                    {
                        tb.Text = "";
                    }
                    break;

                case "tbArticulo":
                    if (tb.Text == "ARTICULO")
                    {
                        tb.Text = "";
                    }
                    break;

                case "tbCantidad":
                    if (tb.Text == "CANTIDAD")
                    {
                        tb.Text = "";
                    }
                    break;

                case "tbAnterior":
                    if (tb.Text == "ANTERIOR")
                    {
                        tb.Text = "";
                    }
                    break;

                default:
                    break;
            }
        }
    }
}