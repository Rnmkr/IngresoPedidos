using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngresoPedidos.Helpers
{
    static class UserRightValidation
    {
        //Obtener el estado de un permiso particular
        static internal bool CanExecute(string nombrePermiso)
        {
            return StaticData.ListaPermisos.First(f => f.NombrePermiso == nombrePermiso).EstadoPermiso;
        }
    }
}
