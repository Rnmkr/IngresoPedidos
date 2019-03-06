using System;
using System.Linq;
using System.Windows;

namespace IngresoPedidos.Helpers
{
    static class PermissionValidation
    {
        //Obtener el estado de un permiso particular
        static internal bool CanExecute(string nombrePermiso)
        {
            try
            {
                if (StaticData.ListaPermisos.First(f => f.NombrePermiso == nombrePermiso).EstadoPermiso)
                {
                    return true;
                }
                else
                {

                    MessageBox.Show("No tiene permiso para: " + nombrePermiso, "Permiso denegado", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return false;
                }
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("La aplicación invocó un permiso que no se encuentra en la base de datos. Consulte al administrador." + Environment.NewLine + "Nombre nombre del permiso: " + nombrePermiso, "Error invocando permiso", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}

