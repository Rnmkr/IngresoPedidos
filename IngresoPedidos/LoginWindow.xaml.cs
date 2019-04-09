using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using IngresoPedidos.DataAccessLayer;
using IngresoPedidos.Helpers;

namespace IngresoPedidos
{
    public partial class LoginWindow : UserControl
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            btnLogin.IsEnabled = false;
            using (new WaitCursor())
            {
                var _legajo = tbLegajo.Text;
                var _password = pbContraseña.Password;
                TryLoginAsync(_legajo, _password);

                //mal todo mal eh, aprende de una vez que tenes que hacer la ventanita...
            }

            btnLogin.IsEnabled = true;
        }

        private void TryLoginAsync(string legajo, string password)
        {



            if (string.IsNullOrWhiteSpace(legajo) || string.IsNullOrWhiteSpace(password))
            {
                return;
            }

            if (legajo == "LEGAJO" || password == "--------")
            {
                return;
            }

            if (ConnectionCheck.Success(StaticData.ServerHostName))
            {
                StaticData.DataBaseContext = new DBContext();
                LoginValidation userValidation = new LoginValidation();

                if (userValidation.CanLogin(legajo, password, "LOGIN"))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
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
                return;
            }

            if (e.Key == System.Windows.Input.Key.Escape)
            {
                //Close();
            }
        }
    }
}

//
//            var _legajo = tbLegajo.Text;
//var _password = pbContraseña.Password;
//await Task.Run(() => TryLogin(_legajo, _password));
//





