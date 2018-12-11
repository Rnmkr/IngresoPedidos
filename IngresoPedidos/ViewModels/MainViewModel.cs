using IngresoPedidos.Helpers;
using IngresoPedidos.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System;

namespace IngresoPedidos.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private PedidosView _selectedPedidoView;
        private PedidosViewRepository _pedidosViewRepository = new PedidosViewRepository();
        private ModelosRepository _modelosRepository = new ModelosRepository();
        private ProductosRepository _productosRepository = new ProductosRepository();

        public MainViewModel()
        {
            PedidosViewList = _pedidosViewRepository.GetPedidosView();
            ModelosList = _modelosRepository.GetModelos();
            LoadProductos();
            WireCommands();
        }

        private void LoadProductos()
        {
            if (SelectedPedidoView != null)
            {
                ProductosList = _productosRepository.GetProductos(SelectedPedidoView.NombreModelo);
            }
        }

        private void WireCommands()
        {
            RefreshDataCommand = new RelayCommand(RefreshData);
            RefreshDataCommand.IsEnabled = true;
        }

        public List<PedidosView> PedidosViewList { get; set; }
        public List<string> ModelosList { get; set; }
        public List<string> ProductosList { get; set; }
        List<string> _estadosList = new List<string> { "DESPACHADO", "CANCELADO", "INGRESADO", "PAUSADO", "PRODUCCION", "INCOMPLETO", "AUTORIZADO", "CONTROLADO" };
        public List<string> EstadosList
        {
            get
            {
                return _estadosList;
            }

            set
            {
                if (_estadosList != value)
                {
                    _estadosList = value;
                    LoadProductos();
                    OnPropertyChanged("EstadosList");
                }
            }
        }

        public PedidosView SelectedPedidoView
        {
            get
            {
                return _selectedPedidoView;
            }

            set
            {
                if (_selectedPedidoView != value)
                {
                    _selectedPedidoView = value;
                    LoadProductos();
                    OnPropertyChanged("SelectedPedidoView");
                }
            }
        }



        public RelayCommand RefreshDataCommand { get; private set; }

        public void RefreshData()
        {
            PedidosViewList = null;
            PedidosViewList = _pedidosViewRepository.GetPedidosView();
            MessageBox.Show("Refrescado perro!");
        }
    }
}

