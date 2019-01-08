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
        private int _dataGridSelectedIndex;

        public MainViewModel()
        {
            PedidosViewList = _pedidosViewRepository.GetPedidosView();
            //SelectLast();
            ModelosList = _modelosRepository.GetModelos();
            ProductosList = _productosRepository.GetProductos();
            DataGridSelectedIndex = -1;
            WireCommands();
        }


        public List<PedidosView> PedidosViewList { get; set; }
        public List<string> ModelosList { get; set; }
        public List<string> ProductosList { get; set; }
        public List<string> EstadosList { get; } = new List<string> { "DESPACHADO", "CANCELADO", "INGRESADO", "PAUSADO", "PRODUCCION", "INCOMPLETO", "AUTORIZADO", "CONTROLADO", "REPROCESADO" };
        public List<string> FiltrosList { get; } = new List<string> { "TODOS", "CANCELADOS", "INGRESADOS", "PAUSADOS", "PRODUCCION", "INCOMPLETOS", "AUTORIZADOS", "CONTROLADOS", "REPROCESADOS" };

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
                    OnPropertyChanged("SelectedPedidoView");
                }
            }
        }

        public int DataGridSelectedIndex
        {
            get
            {
                return _dataGridSelectedIndex;
            }

            set
            {
                if (_dataGridSelectedIndex != value)
                {
                    _dataGridSelectedIndex = value;
                    OnPropertyChanged("DataGridSelectedIndex");
                }
            }
        }

        public RelayCommand RefreshDataCommand { get; private set; }
        public RelayCommand SelectReprocesoCommand { get; private set; }
        public RelayCommand SelectOriginalCommand { get; private set; }

        private void WireCommands()
        {
            RefreshDataCommand = new RelayCommand(RefreshData);
            SelectReprocesoCommand = new RelayCommand(SelectReproceso);
            SelectOriginalCommand = new RelayCommand(SelectOriginal);
            RefreshDataCommand.IsEnabled = true;
            SelectOriginalCommand.IsEnabled = true;
            SelectReprocesoCommand.IsEnabled = true;
        }

        public void SelectReproceso()
        {
            SelectedPedidoView = PedidosViewList.Where(w => w.NumeroPedido == SelectedPedidoView.NumeroReproceso).SingleOrDefault();
        }
        public void SelectOriginal()
        {
            SelectedPedidoView = PedidosViewList.Where(w => w.NumeroPedido == SelectedPedidoView.NumeroOriginal).SingleOrDefault();
        }

        public void SelectLast()
        {
            SelectedPedidoView = PedidosViewList.LastOrDefault();
        }

        public void RefreshData()
        {
            PedidosViewList = null;
            //SelectedPedidoView = null;
            PedidosViewList = _pedidosViewRepository.GetPedidosView();
            DataGridSelectedIndex = -1;
            //PedidosView pv = SelectedPedidoView;
            //MessageBox.Show(pv.NumeroReproceso);
        }
    }
}

