using System;
using System.Windows;
using static IngresoPedidos.SplashScreenCustom;

namespace IngresoPedidos
{
    public partial class SplashScreenCustom : Window, ISplashScreen
    {
        public SplashScreenCustom()
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

