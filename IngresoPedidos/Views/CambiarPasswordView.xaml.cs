﻿using System.Windows;

namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for NewPasswordWindow.xaml
    /// </summary>
    public partial class NewPasswordWindow : Window
    {
        public NewPasswordWindow()
        {
            InitializeComponent();
        }
    }
}

//using IngresoPedidos.Helpers;
//using IngresoPedidos.Models;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace IngresoPedidos.ViewModels
//{
//    class MainViewModel : ViewModelBase
//    {

//        private List<PedidosView> _listaPedidosView;
//        private List<Modelos> _listaModelos;
//        private List<Productos> _listaProductos;
//        private List<string> _listaEstados { get; } = new List<string> { "INGRESADO", "COMPLETO", "INCOMPLETO", "AUTORIZADO", "PRODUCCION", "PAUSADO", "CANCELADO", "REPROCESADO", "DESPACHADOS" };
//        private List<string> _listaFiltros { get; } = new List<string> { "INGRESADO", "COMPLETO", "INCOMPLETO", "AUTORIZADO", "PRODUCCION", "PAUSADO", "CANCELADO", "REPROCESADO", "DESPACHADOS", "ULTIMOS" };
//        private PedidosView _pedidoViewSeleccionado;
//        private Modelos _modeloSeleccionado;
//        private Productos _productoSeleccionado;







//        private PedidosViewRepository _pedidosViewRepository = new PedidosViewRepository();
//        private ModelosRepository _modelosRepository = new ModelosRepository();
//        private ProductosRepository _productosRepository = new ProductosRepository();
//        private int _dataGridSelectedIndex;
//        private string _activeUser;
//        private string _selectedFilter;
//        private List<PedidosView> _pedidosViewList;
//        private List<Modelos> _modelosList;
//        private string _selectedModelo;

//        public MainViewModel()
//        {
//            PedidosViewList = _pedidosViewRepository.GetPedidosView(SelectedFilter).OrderBy(o => o.FechaIngreso).ToList();
//            DataGridSelectedIndex = -1;
//            ModelosList = _modelosRepository.GetModelos();
//            WireCommands();
//        }





//        public List<string> ModelosStringList { get; set; }
//        public List<string> ProductosStringList { get; set; }
//        public List<Productos> ProductosList { get; set; }


//        public List<PedidosView> PedidosViewList
//        {
//            get
//            {
//                return _pedidosViewList;
//            }

//            set
//            {
//                if (_pedidosViewList != value)
//                {
//                    _pedidosViewList = value;
//                    OnPropertyChanged("PedidosViewList");
//                }
//            }
//        }

//        public List<Modelos> ModelosList
//        {
//            get
//            {
//                return _modelosList;
//            }

//            set
//            {
//                if (_modelosList != value)
//                {
//                    _modelosList = value;
//                    OnPropertyChanged("ModelosList");
//                }
//            }
//        }




//        public string SelectedModelo
//        {
//            get
//            {
//                return _selectedModelo;
//            }

//            set
//            {
//                if (_selectedModelo != value)
//                {
//                    _selectedModelo = value;
//                    OnPropertyChanged("SelectedModelo");
//                }
//            }
//        }

//        public PedidosView SelectedPedidoView
//        {
//            get
//            {
//                return _selectedPedidoView;
//            }

//            set
//            {
//                if (_selectedPedidoView != value)
//                {
//                    _selectedPedidoView = value;
//                    OnPropertyChanged("SelectedPedidoView");
//                }
//            }
//        }

//        public string SelectedFilter
//        {
//            get
//            {
//                return _selectedFilter;
//            }

//            set
//            {
//                if (_selectedFilter != value)
//                {

//                    _selectedFilter = value;
//                    OnPropertyChanged("SelectedFilter");
//                    SelectedPedidoView = null;
//                    PedidosViewList = _pedidosViewRepository.GetPedidosView(value).OrderBy(o => o.FechaIngreso).ToList();
//                }
//            }
//        }

//        public int DataGridSelectedIndex
//        {
//            get
//            {
//                return _dataGridSelectedIndex;
//            }

//            set
//            {
//                if (_dataGridSelectedIndex != value)
//                {
//                    _dataGridSelectedIndex = value;
//                    OnPropertyChanged("DataGridSelectedIndex");
//                }
//            }
//        }

//        public RelayCommand CancelBusyIndicatorCommand { get; private set; }
//        public RelayCommand RefreshDataCommand { get; private set; }
//        public RelayCommand SelectReprocesoCommand { get; private set; }
//        public RelayCommand SelectOriginalCommand { get; private set; }
//        public RelayCommand FilterSelectionChangedCommand { get; private set; }
//        public RelayCommand LoadListCommand { get; private set; }

//        private void WireCommands()
//        {


//            RefreshDataCommand = new RelayCommand(RefreshDataAsync);
//            SelectReprocesoCommand = new RelayCommand(SelectReproceso);
//            SelectOriginalCommand = new RelayCommand(SelectOriginal);
//            RefreshDataCommand.IsEnabled = true;
//            SelectOriginalCommand.IsEnabled = true;
//            SelectReprocesoCommand.IsEnabled = true;
//            //CancelBusyIndicatorCommand.IsEnabled = true;
//            CancelBusyIndicatorCommand = new RelayCommand(CancelBusyIndicator);
//            ActiveUser = "{ " + "425" + " }" + " " + "SCHNEIDER NICOLAS";

//        }


//        public void SelectReproceso()
//        {
//            DataBaseContext dbc = new DataBaseContext();
//            PedidosView pv = dbc.PedidosView.Where(w => w.NumeroPedido == SelectedPedidoView.NumeroReproceso).SingleOrDefault();
//            PedidosViewList = _pedidosViewRepository.GetPedidosView(pv.EstadoPedido);
//            SelectedFilter = pv.EstadoPedido;
//            SelectedPedidoView = pv;
//        }

//        public void SelectOriginal()
//        {
//            DataBaseContext dbc = new DataBaseContext();
//            PedidosView pv = dbc.PedidosView.Where(w => w.NumeroPedido == SelectedPedidoView.NumeroOriginal).SingleOrDefault();
//            PedidosViewList = _pedidosViewRepository.GetPedidosView(pv.EstadoPedido);
//            SelectedFilter = pv.EstadoPedido;
//            SelectedPedidoView = pv;
//        }

//        public void SelectLast()
//        {
//            SelectedPedidoView = PedidosViewList.LastOrDefault();
//        }

//        async void RefreshDataAsync()
//        {

//            ProcessingDialog pd = new ProcessingDialog();
//            Task loaddata = GetInvoices(pd);
//            pd.ShowDialog();
//            await loaddata;
//        }

//        async Task GetInvoices(ProcessingDialog pd)
//        {
//            await Task.Delay(500);
//            PedidosViewList = null;
//            var lis = _pedidosViewRepository.GetPedidosView(SelectedFilter);
//            DataGridSelectedIndex = -1;
//            pd.Close();
//        }

//        private bool isBusy;
//        public bool IsBusy
//        {
//            get { return isBusy; }
//            set
//            {
//                isBusy = value;
//                OnPropertyChanged("IsBusy");
//            }
//        }

//        public string ActiveUser { get => _activeUser; set => _activeUser = value; }

//        private void CancelBusyIndicator()
//        {
//            isBusy = false;
//            ProcessingDialog pd = new ProcessingDialog();
//            Task loaddata = GetInvoices(pd);
//            pd.ShowDialog();
//        }

//    }
//}
