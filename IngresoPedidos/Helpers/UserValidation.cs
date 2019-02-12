using System.Linq;
using System.Windows;
using IngresoPedidos.Helpers;

namespace IngresoPedidos
{
    internal class UserValidation
    {
        internal bool CanLogin(string legajo, string password, string nombreAplicacion)
        {
            using (new WaitCursor())
            {
                // Obteniendo usuario
                StaticData.Usuario = StaticData.DataBaseContext.UsuarioView.Where(w => w.LegajoUsuario == legajo).Select(s => s).SingleOrDefault();

                // Comprobando si existe (no uso el método "Any()" para no hacer dos querys)
                if (StaticData.Usuario == null)
                {
                    MessageBox.Show("No se encontró el usuario con legajo " + legajo + ".", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return false;
                }
                else
                {
                    // Obtengo la lista de permisos del usuario
                    StaticData.ListaPermisosUsuario = StaticData.DataBaseContext.PermisoView.Where(w => w.FK_IDUsuario == StaticData.Usuario.IDUsuario).Select(s => s).ToList();
                    bool? userCanUseThisApp;

                    // Si tiene permisos asignados, obtengo el permiso para ejecutar esta aplicación
                    if (StaticData.ListaPermisosUsuario != null)
                    {
                        userCanUseThisApp = StaticData.ListaPermisosUsuario.Where(f => f.NombrePermiso == nombreAplicacion).Select(s => s.EstadoPermiso).SingleOrDefault();
                    }
                    else
                    {
                        MessageBox.Show("El usuario con legajo " + legajo + " no tiene asignado permisos.", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return false;
                    }

                    // Si el usuario no tiene el permiso asignado en la base de datos
                    if (userCanUseThisApp == null)
                    {
                        MessageBox.Show("El usuario con legajo " + legajo + " no tiene asignado el correspondiente permiso a esta aplicación.", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return false;
                    }
                    else
                    {
                        // Pregunto el estado del permiso
                        if ((bool)userCanUseThisApp)
                        {
                            // si es válido (True), compruebo la contraseña
                            var hashedPassword = StaticData.Usuario.HashedPassword;

                            // Si la contraseña en la base de datos es "NULL", muestro la ventana para generar una nueva contraseña
                            if (hashedPassword == null)
                            {
                                CambiarContraseñaWindow cambiarContraseñaWindow = new CambiarContraseñaWindow();
                                cambiarContraseñaWindow.ShowDialog();
                                return false;
                            }
                            else
                            {
                                // Si la contraseña es correcta termino la comprobación y devuelvo True
                                if (PasswordHasher.Verify(password, hashedPassword))
                                {
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Contraseña incorrecta.", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            // Si el permiso existe en la base de datos pero no esta habilitado para usar esta aplicación (False)
                            StaticData.Usuario = null;
                            StaticData.ListaPermisosUsuario = null;
                            MessageBox.Show("El usuario con legajo " + legajo + " no está habilitado para usar esta aplicación.", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            return false;
                        }
                    }
                }
            }
        }

        internal bool GetRightStatus(string nombrePermiso)
        {
            using (new WaitCursor())
            {
                bool rightStatus = StaticData.ListaPermisosUsuario.First(f => f.NombrePermiso == nombrePermiso).EstadoPermiso;
                return rightStatus;
            }

        }
    }
}