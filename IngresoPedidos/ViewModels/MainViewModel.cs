using IngresoPedidos.DataAccessLayer;
using IngresoPedidos.Helpers;
using IngresoPedidos.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace IngresoPedidos.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        //private List<PedidosView> _pedidosViewList;
        //private PedidoView _currentPedidoView;
        //private PedidosViewRepository _repository;

        public MainViewModel()
        {
            //_repository = new PedidosViewRepository();
            //_pedidosViewList = _repository.GetPedidosView();

            WireCommands();
        }

        private void WireCommands()
        {
            ShowUserMenuCommand = new RelayCommand(ShowUserMenu);
        }

        public RelayCommand ShowUserMenuCommand
        {
            get;
            private set;
        }

        //public List<PedidosView> PedidosViewList
        //{
        //    get { return _pedidosViewList; }
        //    set { _pedidosViewList = value; }
        //}

        //public PedidosView CurrentPedido
        //{
        //    get
        //    {
        //        return null;
        //        //return _currentPedidoView;
        //    }

        //    set
        //    {
        //        //if (_currentPedidoView != value)
        //        //{
        //        //    _currentPedidoView = value;
        //        //    OnPropertyChanged("CurrentCustomer");
        //        //    UpdateCustomerCommand.IsEnabled = true;
        //    }
        //}

        private void ShowUserMenu()
        {
            //(sender as Button).ContextMenu.IsEnabled = true;
            //(sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            //(sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            //(sender as Button).ContextMenu.Width = (sender as Button).Width;
            //(sender as Button).ContextMenu.IsOpen = true;
            //_repository.UpdateCustomer(CurrentCustomer);
            MessageBox.Show("PUTAMADREEEE!!!");
        }
    }
}


