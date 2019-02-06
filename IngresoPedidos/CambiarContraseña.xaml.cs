using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IngresoPedidos.DatabaseContext;

namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for NewPassword.xaml
    /// </summary>
    public partial class CambiarContraseñaWindow : Window
    {
        private string Legajo;

        public CambiarContraseñaWindow(string legajo)
        {
            InitializeComponent();
            this.Legajo = legajo;
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
            if (string.IsNullOrWhiteSpace(pbContraseñaActual.Password) || string.IsNullOrWhiteSpace(pbContraseñaNueva1.Password) || string.IsNullOrWhiteSpace(pbContraseñaNueva2.Password))
            {
                return;
            }

            if (pbContraseñaNueva1.Password == pbContraseñaNueva2.Password)
            {
                string hashedPassword = PasswordHasher.Hash(pbContraseñaNueva1.Password);
                Context context = new Context();
                var updatedRecord = context.Usuarios.First(w => w.LegajoUsuario == Legajo).HashedPassword;

                if (PasswordHasher.Verify(pbContraseñaActual.Password, updatedRecord))
                {
                    updatedRecord = hashedPassword;
                    context.SaveChanges();
                    MessageBox.Show("La contraseña se cambió exitosamente!", "Cambiar Contraseña", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("La contraseña actual no es correcta!", "Cambiar Contraseña", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden!", "Cambiar Contraseña", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnGuardarContraseña_Click(object sender, RoutedEventArgs e)
        {
            TryChangePassword();
        }
    }
}
