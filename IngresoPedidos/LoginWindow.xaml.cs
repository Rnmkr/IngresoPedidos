using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using IngresoPedidos.DataAccessLayer;

namespace IngresoPedidos
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            tbLegajo.GotFocus += RemovePlaceholder;
            tbLegajo.LostFocus += AddPlaceholder;
            pbContraseña.LostFocus += AddPlaceholder;
            tbPlaceholderContraseña.GotFocus += RemoveLabelPlaceholder;
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLegajo.Text))
            {
                tbLegajo.Foreground = System.Windows.Media.Brushes.LightGray;
                tbLegajo.Text = "LEGAJO";
            }

            if (string.IsNullOrWhiteSpace(pbContraseña.Password))
            {
                tbPlaceholderContraseña.Visibility = Visibility.Visible;
            }
        }

        private void RemoveLabelPlaceholder(object sender, EventArgs e)
        {
            tbPlaceholderContraseña.Visibility = Visibility.Collapsed;
            pbContraseña.Focus();
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            Label lblPlaceholder = sender as Label;
            if (tbLegajo.Text == "LEGAJO")
            {
                tbLegajo.Foreground = System.Windows.Media.Brushes.Black;
                tbLegajo.Text = "";
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            TryLogin();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            TurnBoxesBackgroundWhite();

            if (e.Key == Key.Return)
            {
                if (!string.IsNullOrWhiteSpace(tbLegajo.Text))
                {
                    tbPlaceholderContraseña.Visibility = Visibility.Collapsed;
                }

                TryLogin();
            }
        }

        private void Box_GotFocus(object sender, RoutedEventArgs e)
        {
            TurnBoxesBackgroundWhite();
        }

        private void TurnBoxesBackgroundWhite()
        {
            tbLegajo.Background = Brushes.White;
            pbContraseña.Background = Brushes.White;
        }

        private void TryLogin()
        {
            if (IsDataFilled())
            {
                TryLogin(tbLegajo.Text, pbContraseña.Password);
            }
        }

        private bool IsDataFilled()
        {
            if (string.IsNullOrWhiteSpace(tbLegajo.Text))
            {
                tbLegajo.Focus();
                tbLegajo.Background = Brushes.Red;
                return false;
            }

            if (string.IsNullOrWhiteSpace(pbContraseña.Password))
            {
                pbContraseña.Focus();
                pbContraseña.Background = Brushes.Red;
                return false;
            }

            TurnBoxesBackgroundWhite();
            return true;
        }

        private void TryLogin(string legajo, string password)
        {
            //get array with Nombre, Apellido and HashedPassword from database
            string[] userData = GetUserData(legajo);
            if (userData[0] == null)
            {
                return;
            }
            string nombre = userData[0];


            string apellido = userData[1];
            int id = Convert.ToInt32(userData[2]);
            string hashedPassword = StaticData.context.Password.First(w => w.FK_IDUsuario == id).HashedPassword;

            //if hashed password is null, show new password dialog
            if (string.IsNullOrWhiteSpace(hashedPassword))
            {
                CambiarContraseñaWindow npw = new CambiarContraseñaWindow(StaticData.Usuario);
                pbContraseña.Password = null;
                Hide();
                npw.ShowDialog();
                Show();
                return;
            }

            //if password matches show main window
            if (PasswordHasher.Verify(password, hashedPassword))
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Contraseña incorrectax!" + Environment.NewLine + Environment.NewLine + "Si no recuerda su contraseña consulte al Administrador.", "Ingreso de Usuario", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                pbContraseña.Password = null;
                pbContraseña.Focus();
            }
        }

        private string[] GetUserData(string legajo)
        {
            //***implement if ping successful***
            DBContext context = new DBContext();

            try
            {
                //get Nombre and Apellido from Usuarios table
                string leg = legajo;
                var user = context.Usuario.First(f => f.LegajoUsuario == leg);

                ////get HashedPassword from Passwords table
                //var hashedPassword = database.Usuarios.First(f => f.FK_Legajo == legajo);

                ////get access levels from Permisos table
                //var accessLevel = database.Permisos.First(f => f.FK_Legajo == legajo);

                //store and return all data in string array
                string[] UserData = new string[] { user.NombreUsuario, user.ApellidoUsuario, user.IDUsuario.ToString() };

                return UserData;
            }
            catch (System.InvalidOperationException io)
            {
                MessageBox.Show(io.ToString());
                //if Legajo not found in database
                MessageBox.Show("No se encontro el usuario en la base de datos o no esta habilitado para este tipo de operaciones." + Environment.NewLine + Environment.NewLine + "Si le fue asignado el puesto, solicite al Administrador que habilite su legajo para Ingreso de Pedidos.", "Ingreso de Usuario", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbLegajo.Text = null;
                pbContraseña.Password = null;
                tbLegajo.Focus();

                string[] UserData = new string[] { null };
                return UserData;
            }
        }

        private bool GetUserAccessLevels(string legajo)
        {

            return false;
        }




    }
}





