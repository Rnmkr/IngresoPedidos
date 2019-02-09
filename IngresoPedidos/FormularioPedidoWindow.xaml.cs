using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using IngresoPedidos.DataAccessLayer;

namespace IngresoPedidos
{
    public partial class FormularioPedidoWindow : Window
    {
        public List<string> listaestados = new List<string> { "AUTORIZADO", "CANCELADO", "COMPLETO", "DESPACHADO", "FINALIZADO", "INCOMPLETO", "INGRESADO", "PAUSADO", "PRODUCCION" };

        public FormularioPedidoWindow()
        {
            InitializeComponent();
            this.Title = "NUEVO PEDIDO";
            cbEstado.SelectedValue= "INGRESADO";
            cbEstado.IsEnabled = false;
            cbEstado.Foreground = System.Windows.Media.Brushes.Gray;
            tbPedido.GotFocus += RemovePlaceholder;
            tbPedido.LostFocus += AddPlaceholder;
            tbArticulo.GotFocus += RemovePlaceholder;
            tbArticulo.LostFocus += AddPlaceholder;
            tbCantidad.GotFocus += RemovePlaceholder;
            tbCantidad.LostFocus += AddPlaceholder;
            tbAnterior.GotFocus += RemovePlaceholder;
            tbAnterior.LostFocus += AddPlaceholder;
            tbObservacion.GotFocus += RemovePlaceholder;
            tbObservacion.LostFocus += AddPlaceholder;
        }

        public FormularioPedidoWindow(PedidoView pedidoseleccionado)
        {
            InitializeComponent();
            this.Title = "EDITAR PEDIDO";
            cbEstado.Foreground = System.Windows.Media.Brushes.Black;
            tbPedido.Foreground = System.Windows.Media.Brushes.Black;
            cbModelo.Foreground = System.Windows.Media.Brushes.Black;
            cbProducto.Foreground = System.Windows.Media.Brushes.Black;
            tbArticulo.Foreground = System.Windows.Media.Brushes.Black;
            tbCantidad.Foreground = System.Windows.Media.Brushes.Black;
            tbAnterior.Foreground = System.Windows.Media.Brushes.Black;
            tbObservacion.GotFocus += RemovePlaceholder;
            tbObservacion.LostFocus += AddPlaceholder;
            PedidoView pedidoSeleccionado = new PedidoView {IDPedido = 0, NumeroArticulo = "2448", CantidadEquipos = 200, NombreEstado = "AUTORIZADO", FechaEstado = DateTime.Now, FechaIngreso = DateTime.Now, NombreModelo = "H8", NombreProducto = "ALL-IN-ONE", NumeroPedido = "1234567A-00", NumeroPedidoAnterior = "1111111A-00", NumeroPedidoSucesor ="2222222A-00" };
            tbPedido.Text = pedidoSeleccionado.NumeroPedido;
            tbPedido.IsEnabled = false;
            cbEstado.ItemsSource = listaestados;
            cbModelo.SelectedValue = pedidoSeleccionado.NombreModelo;
            cbModelo.SelectedValue = pedidoSeleccionado.NombreProducto;
            tbArticulo.Text = pedidoSeleccionado.NumeroArticulo;
            tbCantidad.Text = pedidoSeleccionado.CantidadEquipos.ToString();
            cbEstado.SelectedValue = pedidoSeleccionado.NombreEstado;
            tbAnterior.Text = pedidoSeleccionado.NumeroPedidoAnterior;
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
            tbPedido.Text = tbPedido.Text.ToUpper();
            tbAnterior.Text = tbAnterior.Text.ToUpper();
            tbObservacion.Text = tbObservacion.Text.ToUpper();

            TextBox tb = sender as TextBox;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Foreground = System.Windows.Media.Brushes.LightGray;

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

                    case "tbObservacion":
                        tb.Text = "OBSERVACION";
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

                case "tbObservacion":
                    if (tb.Text == "OBSERVACION")
                    {
                        tb.Text = "";
                    }
                    break;

                default:
                    break;
            }
        }

        private void cbModelo_DropDownOpened(object sender, EventArgs e)
        {
            cbModelo.Foreground = System.Windows.Media.Brushes.Black;
        }

        private void cbModelo_DropDownClosed(object sender, EventArgs e)
        {
            if (cbModelo.SelectedIndex == -1)
            {
                cbModelo.Foreground = System.Windows.Media.Brushes.LightGray;
            }
        }

        private void cbProducto_DropDownOpened(object sender, EventArgs e)
        {
            cbProducto.Foreground = System.Windows.Media.Brushes.Black;
        }

        private void cbProducto_DropDownClosed(object sender, EventArgs e)
        {
            if (cbProducto.SelectedIndex == -1)
            {
                cbProducto.Foreground = System.Windows.Media.Brushes.LightGray;
            }
        }

        private void cbEstado_DropDownOpened(object sender, EventArgs e)
        {
            cbEstado.Foreground = System.Windows.Media.Brushes.Black;
        }

        private void cbEstado_DropDownClosed(object sender, EventArgs e)
        {
            if (cbEstado.SelectedIndex == -1)
            {
                cbEstado.Foreground = System.Windows.Media.Brushes.LightGray;
            }
        }
    }
}