using System;
using System.Windows;
using static IngresoPedidos.Views.SplashScreenView;

namespace IngresoPedidos.Views
{
    public partial class SplashScreenView : Window, ISplashScreen
    {
        public SplashScreenView()
        {
            InitializeComponent();
        }

        public void AddMessage(string message)
        {
            Dispatcher.Invoke((Action)delegate ()
            {
                this.lblEstado.Content = message;
            });
        }

        public void LoadComplete()
        {
            Dispatcher.InvokeShutdown();
        }


        public interface ISplashScreen
        {
            void AddMessage(string message);
            void LoadComplete();
        }
    }
}

