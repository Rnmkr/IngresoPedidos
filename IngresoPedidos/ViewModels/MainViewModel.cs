using IngresoPedidos.Helpers;
using IngresoPedidos.Models;
using System.Collections.Generic;
using System.Windows;
using IngresoPedidos.DataAccessLayer;

namespace IngresoPedidos.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private PedidosView _currentPedidosView;


        public RelayCommand ShowUserMenuCommand
        {
            get;
            private set;
        }

        public MainViewModel()
        {
            PedidosViewRepository _repository = new PedidosViewRepository();
            PedidosViewList = _repository.GetPedidosViewRepository();

            WireCommands();
        }


        private void WireCommands()
        {
            ShowUserMenuCommand = new RelayCommand(ShowUserMenu);
            ShowUserMenuCommand.IsEnabled = true;
        }


        public List<PedidosView> PedidosViewList { get; set; }

        public PedidosView CurrentPedido
        {
            get
            {
                return _currentPedidosView;
            }

            set
            {
                if (_currentPedidosView != value)
                {
                    _currentPedidosView = value;
                    OnPropertyChanged("CurrentPedido");
                    //UpdateCustomerCommand.IsEnabled = true;
                }
            }
        }

        private void ShowUserMenu()
        {
            MessageBox.Show("PUTAMADREEEE!!!");
        }
    }
}


