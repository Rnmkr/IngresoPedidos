using System;
using System.Collections.Generic;
using System.Windows;

namespace IngresoPedidos
{
    public partial class FiltroListaWindow : Window
    {
        public FiltroListaWindow()
        {
            InitializeComponent();
            List<string> listafiltros = new List<string> { "AUTORIZADO", "CANCELADO", "COMPLETO", "DESPACHADO", "FINALIZADO", "INCOMPLETO", "INGRESADO", "PAUSADO", "PRODUCCION", "REPROCESADO", "SUCESORES", "ULTIMOS 10000", "PERSONALIZADA", "BUSQUEDA" };
            cbFiltros.ItemsSource = listafiltros;
        }

        private void btnAplicarFiltro_Click(object sender, RoutedEventArgs e)
        {
            AplicarFiltro();
        }

        private void OnKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                AplicarFiltro();
            }

            if (e.Key == System.Windows.Input.Key.Escape)
            {
                Close();
            }
        }

        private void AplicarFiltro()
        {
            Close();
        }
    }
}
