using IngresoPedidos.Helpers;
using IngresoPedidos.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Threading;

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

        public RelayCommand CancelBusyIndicatorCommand { get; private set; }
        public RelayCommand RefreshDataCommand { get; private set; }
        public RelayCommand SelectReprocesoCommand { get; private set; }
        public RelayCommand SelectOriginalCommand { get; private set; }

        private void WireCommands()
        {
            RefreshDataCommand = new RelayCommand(RefreshDataAsync);
            SelectReprocesoCommand = new RelayCommand(SelectReproceso);
            SelectOriginalCommand = new RelayCommand(SelectOriginal);
            RefreshDataCommand.IsEnabled = true;
            SelectOriginalCommand.IsEnabled = true;
            SelectReprocesoCommand.IsEnabled = true;
            //CancelBusyIndicatorCommand.IsEnabled = true;
            CancelBusyIndicatorCommand = new RelayCommand(CancelBusyIndicator);
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

        async void RefreshDataAsync()
        {

            ProcessingDialog pd = new ProcessingDialog();
            Task loaddata = GetInvoices(pd);
            pd.ShowDialog();
            await loaddata;
        }

        async Task GetInvoices(ProcessingDialog pd)
        {
            await Task.Delay(500);
            PedidosViewList = null;
            var lis = _pedidosViewRepository.GetPedidosView();
            DataGridSelectedIndex = -1;
            pd.Close();
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        private void CancelBusyIndicator()
        {
            isBusy = false;
            ProcessingDialog pd = new ProcessingDialog();
            Task loaddata = GetInvoices(pd);
            pd.ShowDialog();
        }

    }
}

