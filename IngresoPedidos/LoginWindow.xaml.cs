using System.Linq;
using System.Reflection;
using System.Windows;
using IngresoPedidos.DataAccessLayer;
using IngresoPedidos.Helpers;

namespace IngresoPedidos
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            TryLogin();
        }

        private void TryLogin()
        {
            if (!string.IsNullOrWhiteSpace(tbLegajo.Text) && !string.IsNullOrWhiteSpace(pbContraseña.Password))
            {
                if (tbLegajo.Text != "LEGAJO" && pbContraseña.Password != "--------")
                {
                    if (ConnectionCheck.Success(StaticData.ServerHostName))
                    {
                        StaticData.DataBaseContext = new DBContext();
                        UserValidation userValidation = new UserValidation();

                        if (userValidation.CanLogin(tbLegajo.Text, pbContraseña.Password, "IngresoPedidos"))
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            Close();
                        }
                    }
                }
            }
        }

        private void TbLegajo_GotFocus(object sender, RoutedEventArgs e)
        {
            tbLegajo.SelectAll();
        }

        private void PbContraseña_GotFocus(object sender, RoutedEventArgs e)
        {
            pbContraseña.SelectAll();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                TryLogin();
            }

            if (e.Key == System.Windows.Input.Key.Escape)
            {
                Close();
            }
        }
    }
}





