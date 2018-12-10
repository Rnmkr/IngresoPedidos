using IngresoPedidos.DataAccessLayer;
using IngresoPedidos.Helpers;
using IngresoPedidos.Models;
using System.Collections.Generic;

namespace IngresoPedidos.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private List<PedidosView> _pedidosViewList;
        private PedidoView _currentPedidoView;
        private PedidosViewRepository _repository;

        public MainViewModel()
        {
            _repository = new PedidosViewRepository();
            _pedidosViewList = _repository.GetPedidosView();

            WireCommands();
        }

        private void WireCommands()
        {
            UpdateCustomerCommand = new RelayCommand(UpdateCustomer);
        }

        public RelayCommand UpdateCustomerCommand
        {
            get;
            private set;
        }

        public List<PedidosView> PedidosViewList
        {
            get { return _pedidosViewList; }
            set { _pedidosViewList = value; }
        }

        public PedidosView CurrentPedido
        {
            get
            {
                return null;
                //return _currentPedidoView;
            }

            set
            {
                //if (_currentPedidoView != value)
                //{
                //    _currentPedidoView = value;
                //    OnPropertyChanged("CurrentCustomer");
                //    UpdateCustomerCommand.IsEnabled = true;
            }
        }

        public void UpdateCustomer()
        {
            //_repository.UpdateCustomer(CurrentCustomer);
        }
    }
}


