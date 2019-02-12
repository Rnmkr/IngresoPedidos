using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        private void TryChangePassword()
        {
            if (string.IsNullOrWhiteSpace(pbContraseñaActual.Password))
            {
                if (StaticData.Usuario.HashedPassword != null)
                {
                    if (!PasswordHasher.Verify(StaticData.Usuario.HashedPassword, pbContraseñaActual.Password))
                    {
                        MessageBox.Show("Las contraseña actual no es correcta.", "Cambiar Contraseña", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(pbContraseñaNueva1.Password))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(pbContraseñaNueva2.Password))
            {
                return;
            }

            if (pbContraseñaNueva1.Password != pbContraseñaNueva2.Password)
            {
                MessageBox.Show("Las contraseñas nuevas no coinciden!", "Cambiar Contraseña", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                if (ConnectionCheck.Success())
                {
                    using (new WaitCursor())
                    {
                        Contraseña dbpass = StaticData.context.Contraseña.Where(w => w.FK_IDUsuario == StaticData.Usuario.IDUsuario).Select(s => s).SingleOrDefault();
                        var newPassword = PasswordHasher.Hash(pbContraseñaNueva1.Password);
                        dbpass.HashedPassword = newPassword;
                        StaticData.context.SaveChanges();
                        MessageBox.Show("La contraseña se cambió exitosamente!", "Cambiar Contraseña", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                }
            }
        }

        private void btnGuardarContraseña_Click(object sender, RoutedEventArgs e)
        {
            TryChangePassword();
        }
    }
}
