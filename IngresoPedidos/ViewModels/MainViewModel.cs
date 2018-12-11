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
        public List<PedidosView> PedidosViewList { get; set; }
        public PedidosView CurrentPedidosView { get; set; }

        public MainViewModel()
        {
            DataBaseContext dbc = new DataBaseContext();
            PedidosViewList = dbc.PedidosView.Select(s => s).ToList();

            WireCommands();
        }

        private void WireCommands()
        {
           // throw new NotImplementedException();
        }
    }
}

