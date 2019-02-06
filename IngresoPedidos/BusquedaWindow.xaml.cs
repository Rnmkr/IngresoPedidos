using IngresoPedidos.Helpers;
using System;
using System.Collections.Generic;
using System.Windows;

namespace IngresoPedidos
{
    public partial class BusquedaWindow : Window
    {
        public BusquedaWindow()
        {
            InitializeComponent();
            tbKeyword.GotFocus += RemovePlaceholder;
            tbKeyword.LostFocus += AddPlaceholder;
            List<string> campos = new List<string> { "PEDIDO", "MODELO", "PRODUCTO", "ARTICULO", "CANTIDAD", "ESTADO", "SUCESOR", "ANTERIOR" };
            List<string> camposfecha = new List<string> { "FECHA INGRESO", "FECHA ESTADO" };
            cbCampo.ItemsSource = campos;
            cbCampoFecha.ItemsSource = camposfecha;
            dpFechaInicial.DisplayDateEnd = DateTime.Today;
            dpFechaFinal.DisplayDateEnd = DateTime.Today;
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

        private void OnKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                BuscarRegistro();
            }

            if (e.Key == System.Windows.Input.Key.Escape)
            {
                Close();
            }
        }

        private void btnIniciarBusqueda_Click(object sender, RoutedEventArgs e)
        {
            BuscarRegistro();
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
            DateTime fechainicio = dpFechaInicial.SelectedDate ?? DateTime.Now;
            DateTime fechafinal = dpFechaFinal.SelectedDate ?? DateTime.Now;
            StaticData.SearchList = busqueda.ObtenerPedidos(keyword, campo, campofecha, fechainicio, fechafinal);
        }
    }
}
