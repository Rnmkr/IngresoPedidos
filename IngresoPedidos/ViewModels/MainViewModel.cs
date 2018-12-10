using IngresoPedidos.Models;
using System.Windows.Input;

namespace IngresoPedidos.ViewModels
{
    class MainViewModel
    {
        public PedidoCollection ListaPedidos { get; set; } = new PedidoCollection();
        public Pedido SelectedPedido { get; set; }

        private ICommand _menu;
        private ICommand _guardar;
        private ICommand _buscar;
        private ICommand _nuevo;
        private ICommand _filtrar;
        private ICommand _seleccion;

        public ICommand CargarPedidos { get; set; }


    }
}
