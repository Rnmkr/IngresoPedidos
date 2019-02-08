using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IngresoPedidos.DataAccessLayer;

namespace IngresoPedidos
{
    /// <summary>
    /// Interaction logic for NewPassword.xaml
    /// </summary>
    public partial class CambiarContraseñaWindow : Window
    {
        private UsuarioView usuarioLogin;

        public CambiarContraseñaWindow(bool renovarPassword, UsuarioView usuario)
        {
            InitializeComponent();
            this.usuarioLogin = usuario;
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
                return;
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
            }

            if (pbContraseñaNueva1.Password == pbContraseñaNueva2.Password)
            {
                DBContext context = new DBContext();
                //int userid = context.Usuario.First(w => w.LegajoUsuario == StaticData.Usuario.LegajoUsuario).IDUsuario;
                string hashedPassword = PasswordHasher.Hash(pbContraseñaNueva1.Password);
                Contraseña userPassword = context.Contraseña.Where(w => w.FK_IDUsuario == 18).Select(s => s).SingleOrDefault();

                if (PasswordHasher.Verify(pbContraseñaActual.Password, userPassword.HashedPassword))
                {
                    userPassword.HashedPassword = hashedPassword;
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

            }
        }

        private void btnGuardarContraseña_Click(object sender, RoutedEventArgs e)
        {
            DBContext dbc = new DBContext();
            IQueryable<PermisoView> lpv = dbc.PermisoView.Where(w => w.FK_IDUsuario == 18).Select(s => s);
            //List<string> lp = lpv.Where(w => w.EstadoPermiso == true).Select(s => s.NombrePermiso).ToList();
            foreach (var v in lpv)
            {
                MessageBox.Show(v.FK_IDUsuario.ToString() + " " + v.NombrePermiso.ToString() + " " + v.EstadoPermiso.ToString());
            }

        }
    }
}
