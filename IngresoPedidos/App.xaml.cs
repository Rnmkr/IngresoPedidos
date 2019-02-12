using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using static IngresoPedidos.SplashScreenCustom;

namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region SplashScreen fields

        public static ISplashScreen splashScreen;
        private ManualResetEvent ResetSplashCreated;
        private Thread SplashThread;

        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            #region Single Instance check

            Process proc = Process.GetCurrentProcess();
            int count = Process.GetProcesses().Where(p => p.ProcessName == proc.ProcessName).Count();
            if (count > 1)
            {
                //MessageBox.Show("Already an instance is running...");
                App.Current.Shutdown();
            }

            #endregion

            #region SplashScreen Methods

            //// ManualResetEvent acts as a block. It waits for a signal to be set.
            //ResetSplashCreated = new ManualResetEvent(false);

            //// Create a new thread for the splash screen to run on
            //SplashThread = new Thread(ShowSplash);
            //SplashThread.SetApartmentState(ApartmentState.STA);
            //SplashThread.IsBackground = true;
            //SplashThread.Name = "Splash Screen";
            //SplashThread.Start();

            //// Wait for the blocker to be signaled before continuing. This is essentially the same as: while(ResetSplashCreated.NotSet) {}
            //ResetSplashCreated.WaitOne();
            //base.OnStartup(e);
        }

        private void ShowSplash()
        {
            //// Create the window
            //SplashScreenCustom animatedSplashScreenWindow = new SplashScreenCustom();
            //splashScreen = animatedSplashScreenWindow;

            //// Show it
            //animatedSplashScreenWindow.Show();

            //// Now that the window is created, allow the rest of the startup to run
            //ResetSplashCreated.Set();
            //System.Windows.Threading.Dispatcher.Run();
        }

        #endregion
    }
}






