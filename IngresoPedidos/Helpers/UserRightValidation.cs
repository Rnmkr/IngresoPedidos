using System.Linq;
using System.Windows;

namespace IngresoPedidos.Helpers
{
    static class UserRightValidation
    {
        //Obtener el estado de un permiso particular
        static internal bool CanExecute(string nombrePermiso)
        {
            if (StaticData.ListaPermisos.First(f => f.NombrePermiso == nombrePermiso).EstadoPermiso)
            {
                return true;
            }
            else
            {
                MessageBox.Show("No tiene permisos suficientes para: " + nombrePermiso, "Permiso denegado", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }
        }
    }
}
