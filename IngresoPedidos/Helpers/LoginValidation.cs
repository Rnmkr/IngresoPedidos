using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using IngresoPedidos.Helpers;

namespace IngresoPedidos
{
    internal class UserValidation
    {
        internal bool CanLogin(string legajo, string password, string nombreAplicacion)
        {
            //Compruebo que el legajo este compuesto solo de numeros
            Regex regex = new Regex(@"^\d+$");
            if (!regex.IsMatch(legajo))
            {
                MessageBox.Show("Formato incorrecto en Legajo.", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            //Obteniendo usuario
            StaticData.Usuario = StaticData.DataBaseContext.UsuarioView.Where(w => w.LegajoUsuario == legajo).Select(s => s).SingleOrDefault();

            //Comprobando si existe (no uso el método "Any()" para no hacer dos querys)
            if (StaticData.Usuario == null)
            {
                MessageBox.Show("No se encontró el usuario con legajo " + legajo + ".", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            // Si la contraseña en la base de datos es "NULL", muestro la ventana para generar una nueva contraseña
            if (StaticData.Usuario.HashedPassword == null)
            {
                CambiarContraseñaWindow cambiarContraseñaWindow = new CambiarContraseñaWindow();
                cambiarContraseñaWindow.ShowDialog();
                return false;
            }

            //Compruebo que la contraseña sea correcta y obtengo la lista de permisos del usuario
            if (PasswordHasher.Verify(password, StaticData.Usuario.HashedPassword))
            {
                StaticData.ListaPermisos = StaticData.DataBaseContext.PermisoView.Where(w => w.FK_IDUsuario == StaticData.Usuario.IDUsuario).Select(s => s).ToList();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta.", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            //Compruebo si el usuario tiene permiso para usar la aplicación
            //Al dar de alta un usuario en la Base de Datos, es necesario inicializar TODOS
            //los permisos existentes, o se obtendria una excepción en este punto
            if (StaticData.ListaPermisos.Where(f => f.NombrePermiso == nombreAplicacion).Select(s => s.EstadoPermiso).Single())
            {
                return true;
            }
            else
            {
                StaticData.Usuario = null;
                StaticData.ListaPermisos = null;
                MessageBox.Show("No tiene permiso para usar esta aplicación.", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
        }
    }
}