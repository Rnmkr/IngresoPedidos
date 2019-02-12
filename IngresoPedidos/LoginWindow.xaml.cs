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
            if (!string.IsNullOrWhiteSpace(tbLegajo.Text) && !string.IsNullOrWhiteSpace(pbContraseña.Password))
            {
                TryLogin(tbLegajo.Text, pbContraseña.Password);
            }
        }

        private void TryLogin(string legajo, string password)
        {
            if (ConnectionCheck.Success())
            {
                StaticData.context = new DBContext();

                UserValidation userValidation = new UserValidation();
                if (userValidation.CanLogin(legajo, password, "IngresoPedidos"))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
            }
        }


        //    StaticData.Usuario = ObtenerUsuario(legajo);
        //    if (StaticData.Usuario == null)
        //    {
        //        this.Hide();
        //        MessageBox.Show("No se encontró el usuario con legajo " + legajo + " en la base de datos", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
        //        this.Show();
        //    }
        //    else
        //    {
        //        if (ContraseñaValida())
        //        {
        //            if (PuedeOperar())
        //            {
        //                MainWindow mainWindow = new MainWindow();
        //                mainWindow.Show();
        //                Close();
        //            }
        //            else
        //            {
        //                this.Hide();
        //                MessageBox.Show("No tiene permisos para operar pedidos", "Login", MessageBoxButton.OK, MessageBoxImage.Stop);
        //                this.Show();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Contraseña incorrecta", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //}


        //private UsuarioView ObtenerUsuario(string legajo)
        //{
        //    UsuarioView u = StaticData.context.UsuarioView.Where(w => w.LegajoUsuario == legajo).SingleOrDefault();
        //    return u;
        //}

        //private bool ContraseñaValida()
        //{
        //    return false;
        //}

        //private bool PuedeOperar()
        //{
        //    return false;
        //}


        //private void TryLogin(string legajo, string password)
        //{
        //    //get array with Nombre, Apellido and HashedPassword from database
        //    string[] userData = GetUserData(legajo);
        //    if (userData[0] == null)
        //    {
        //        return;
        //    }
        //    string nombre = userData[0];


        //    string apellido = userData[1];
        //    int id = Convert.ToInt32(userData[2]);
        //    string hashedPassword = StaticData.context.Password.First(w => w.FK_IDUsuario == id).HashedPassword;

        //    //if hashed password is null, show new password dialog
        //    if (string.IsNullOrWhiteSpace(hashedPassword))
        //    {
        //        CambiarContraseñaWindow npw = new CambiarContraseñaWindow(true, StaticData.Usuario);
        //        pbContraseña.Password = null;
        //        Hide();
        //        npw.ShowDialog();
        //        Show();
        //        return;
        //    }

        //    //if password matches show main window
        //    if (PasswordHasher.Verify(password, hashedPassword))
        //    {
        //        MainWindow mw = new MainWindow();
        //        mw.Show();
        //        Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Contraseña incorrectax!" + Environment.NewLine + Environment.NewLine + "Si no recuerda su contraseña consulte al Administrador.", "Ingreso de Usuario", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //        pbContraseña.Password = null;
        //        pbContraseña.Focus();
        //    }
        //}

        //private string[] GetUserData(string legajo)
        //{
        //    //***implement if ping successful***
        //    DBContext context = new DBContext();

        //    try
        //    {
        //        //get Nombre and Apellido from Usuarios table
        //        string leg = legajo;
        //        var user = context.Usuario.First(f => f.LegajoUsuario == leg);

        //        ////get HashedPassword from Passwords table
        //        //var hashedPassword = database.Usuarios.First(f => f.FK_Legajo == legajo);

        //        ////get access levels from Permisos table
        //        //var accessLevel = database.Permisos.First(f => f.FK_Legajo == legajo);

        //        //store and return all data in string array
        //        string[] UserData = new string[] { user.NombreUsuario, user.ApellidoUsuario, user.IDUsuario.ToString() };

        //        return UserData;
        //    }
        //    catch (System.InvalidOperationException io)
        //    {
        //        MessageBox.Show(io.ToString());
        //        //if Legajo not found in database
        //        MessageBox.Show("No se encontro el usuario en la base de datos o no esta habilitado para este tipo de operaciones." + Environment.NewLine + Environment.NewLine + "Si le fue asignado el puesto, solicite al Administrador que habilite su legajo para Ingreso de Pedidos.", "Ingreso de Usuario", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        tbLegajo.Text = null;
        //        pbContraseña.Password = null;
        //        tbLegajo.Focus();

        //        string[] UserData = new string[] { null };
        //        return UserData;
        //    }
        //}

        //private bool GetUserAccessLevels(string legajo)
        //{

        //    return false;
        //}




    }
}





