using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using IngresoPedidos.Helpers;

namespace IngresoPedidos
{
    public partial class FiltroListaWindow : Window
    {
        public FiltroListaWindow()
        {
            InitializeComponent();
            List<string> listafiltros = new List<string> { "AUTORIZADO", "CANCELADO", "COMPLETO", "DESPACHADO", "FINALIZADO", "INCOMPLETO", "INGRESADO", "PAUSADO", "PRODUCCION", "REPROCESADO", "SUCESORES", "ULTIMOS 10000", "PERSONALIZADA", "BUSQUEDA" };
            cbFiltros.ItemsSource = listafiltros;
            cbFiltros.SelectedValue = StaticData.FiltroSeleccionado;

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
            StaticData.FiltroSeleccionado = cbFiltros.SelectedValue.ToString();
            if (StaticData.FiltroSeleccionado == "PERSONALIZADA")
            {
                StaticData.ListaPrincipal = StaticData.ListaPersonalizada;
                Close();
                return;
            }
            StaticData.ListaPrincipal = StaticData.DataBaseContext.PedidoView.Where(w => w.NombreEstado == StaticData.FiltroSeleccionado).Select(s => s).ToList();
            Close();
        }
    }
}
