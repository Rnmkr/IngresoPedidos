using System;
using System.Windows.Input;

namespace IngresoPedidos.Helpers
{
    public class RelayCommand : ICommand
    {
        private readonly Action _handler;
        private bool _isEnabled;
        private RelayCommand loadList;

        public RelayCommand(Action handler)
        {
            _handler = handler;
        }

        public RelayCommand(RelayCommand loadList)
        {
            this.loadList = loadList;
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _handler();
        }
    }
}