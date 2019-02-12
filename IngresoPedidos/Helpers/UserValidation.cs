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
                //getting the user from database
                StaticData.Usuario = StaticData.context.UsuarioView.Where(w => w.LegajoUsuario == legajo).Select(s => s).SingleOrDefault();

                //checking if user exist in database
                if (StaticData.Usuario == null)
                {
                    MessageBox.Show("No se encontró el usuario " + legajo + ".", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return false;
                }
                else
                {
                    //As user exists, load its rights
                    StaticData.ListaPermisosUsuario = StaticData.context.PermisoView.Where(w => w.FK_IDUsuario == StaticData.Usuario.IDUsuario).Select(s => s).ToList();

                    //ask if user can use this app
                    bool? userCanUseThisApp = StaticData.ListaPermisosUsuario.First(f => f.NombrePermiso == nombreAplicacion).EstadoPermiso;

                    //check if right exist on database
                    if (userCanUseThisApp == null)
                    {
                        MessageBox.Show("El usuario " + legajo + " no tiene asignado el permiso para usar esta aplicación.", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return false;
                    }
                    else
                    {
                        //check right status
                        if ((bool)userCanUseThisApp)
                        {
                            //as right is true, check user password
                            var hashedPassword = StaticData.Usuario.HashedPassword;

                            //if user password in database == null, show "new password" window
                            if (hashedPassword == null)
                            {
                                CambiarContraseñaWindow cambiarContraseñaWindow = new CambiarContraseñaWindow();
                                cambiarContraseñaWindow.ShowDialog();
                                return false;
                            }
                            else
                            {
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
                            StaticData.Usuario = null;
                            StaticData.ListaPermisosUsuario = null;
                            MessageBox.Show("El usuario " + legajo + " no tiene permiso para usar esta aplicación.", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
                if (StaticData.ListaPermisosUsuario == null)
                {
                    MessageBox.Show("Error: No se encontró la lista de permisos.", Application.Current.MainWindow.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    bool rightStatus = StaticData.ListaPermisosUsuario.First(f => f.NombrePermiso == nombrePermiso).EstadoPermiso;
                    return rightStatus;
                }

            }
        }
    }
}