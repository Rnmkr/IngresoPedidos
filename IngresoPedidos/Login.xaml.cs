using System.Windows;

namespace IngresoPedidos.Views
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ValidarUsuario();
        }

        private void ValidarUsuario()
        {
            
        }
    }
}
