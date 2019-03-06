using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using IngresoPedidos.Helpers;
using System.Reflection;

namespace IngresoPedidos.Helpers
{
    public class LoginValidation
    {
        public bool CanLogin(string legajo, string password, string nombrePermiso)
        {
            StaticData.DataBaseContext = new DataAccessLayer.DBContext();
            //Compruebo que el legajo este compuesto solo de numeros
            Regex regex = new Regex(@"^\d+$");
            if (!regex.IsMatch(legajo))
            {
                MessageBox.Show("Formato incorrecto en Legajo.", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            //Intento obtener el usuario desde la base de datos
            StaticData.Usuario = StaticData.DataBaseContext.UsuarioView.Where(w => w.LegajoUsuario == legajo).Select(s => s).SingleOrDefault();

            //Compruebo si existe el usuario (no uso el método "Any()" para no hacer dos querys a la BD)
            if (StaticData.Usuario == null)
            {
                MessageBox.Show("No se encontró el usuario con legajo " + legajo + ".", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            //Si la contraseña en la base de datos es "NULL", muestro la ventana para generar una nueva contraseña
            if (StaticData.Usuario.HashedPassword == null)
            {
                CambiarContraseñaWindow cambiarContraseñaWindow = new CambiarContraseñaWindow();
                cambiarContraseñaWindow.ShowDialog();
                return false;
            }

            //Compruebo que la contraseña sea correcta y obtengo la lista de permisos del usuario
            if (PasswordHasher.Verify(password, StaticData.Usuario.HashedPassword))
            {
                string appName = Assembly.GetExecutingAssembly().GetName().Name;
                var listaPermisosUsuario = StaticData.DataBaseContext.PermisoView.Where(f => f.FK_IDUsuario == StaticData.Usuario.IDUsuario).Select(s => s);
                StaticData.ListaPermisos = listaPermisosUsuario.Where(w => w.NombreAplicacion == appName).Select(s => s).ToList();

                //Compruebo si el usuario tiene permiso para usar la aplicación
                return UserRightValidation.CanExecute(nombrePermiso);
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta.", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
        }
    }
}