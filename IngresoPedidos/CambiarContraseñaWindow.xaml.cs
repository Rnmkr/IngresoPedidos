using System;
using System.Linq;
using System.Windows;
using IngresoPedidos.DataAccessLayer;
using IngresoPedidos.Helpers;

namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for NewPassword.xaml
    /// </summary>
    public partial class CambiarContraseñaWindow : Window
    {

        public CambiarContraseñaWindow()
        {
            InitializeComponent();
        }

        private void OnKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                TryChangePassword();
            }

            if (e.Key == System.Windows.Input.Key.Escape)
            {
                Close();
            }
        }

        private void btnGuardarContraseña_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pbContraseñaNueva1.Password) || string.IsNullOrWhiteSpace(pbContraseñaNueva2.Password))
            {
                return;
            }

            if (StaticData.Usuario.HashedPassword == null)
            {
                TryChangePassword();
            }
            else
            {
                if (PasswordHasher.Verify(StaticData.Usuario.HashedPassword, pbContraseñaActual.Password))
                {
                    TryChangePassword();
                }
                else
                {
                    MessageBox.Show("La contraseña actual no es correcta.", "Cambiar Contraseña", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
            }
        }

        private void TryChangePassword()
        {
            if (pbContraseñaNueva1.Password == pbContraseñaNueva2.Password)
            {
                if (ConnectionCheck.Success(StaticData.ServerHostName))
                {
                    using (new WaitCursor())
                    {
                        Password contraseña = StaticData.DataBaseContext.Password.Where(w => w.FK_IDUsuario == StaticData.Usuario.IDUsuario).Select(s => s).SingleOrDefault();
                        var newPassword = PasswordHasher.Hash(pbContraseñaNueva1.Password);
                        try
                        {
                            contraseña.HashedPassword = newPassword;
                        }
                        catch (NullReferenceException)
                        {
                            Password contraseñaNueva = new Password();
                            contraseñaNueva.FK_IDUsuario = StaticData.Usuario.IDUsuario;
                            contraseñaNueva.HashedPassword = newPassword;
                            StaticData.DataBaseContext.Password.Add(contraseñaNueva);
                        }

                        StaticData.DataBaseContext.SaveChanges();
                        MessageBox.Show("La contraseña se cambió exitosamente!", "Cambiar Contraseña", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas nuevas no coinciden!", "Cambiar Contraseña", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
        }
    }
}

