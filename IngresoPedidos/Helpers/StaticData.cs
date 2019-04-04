using IngresoPedidos.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace IngresoPedidos.Helpers
{
    public static class StaticData
    {
        // Variable para realizar comprobacion de conexión (ConnectionCheck)
        public static string ServerHostName { get; } = "localhost";

        // ConnectionString para DBContext de EntityFramework (DataAccessLayer)
        internal static readonly string ConnectionString = "data source=VM-FORREST;initial catalog=PRODUCCION;persist security info=True;user id=FORREST;password=12345678;MultipleActiveResultSets=True;App=EntityFramework";
        //internal static readonly string ConnectionString = "data source=DESKTOP;initial catalog=PRODUCCION;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        // Contexto de base de datos para toda la aplicación, se inicializa al intentar loguear con datos válidos
        public static DBContext DataBaseContext { get; set; }

        // Usuario activo se inicializa al loguear exitosamente (UserValidation)
        public static UsuarioView Usuario { get; set; }

        // Lista de permisos del usuario activo, se inicializa al loguear exitosamente (UserValidation)
        public static List<PermisoView> ListaPermisos { get; set; }

        // Lista principal con el contenido filtrado por "Estado"
        public static List<PedidoView> ListaPrincipal { get; set; }

        // Lista resultado de una búsqueda
        public static List<PedidoView> ListaBusqueda { get; set; }

        // Lista de registros "Personalizada" del usuario
        public static List<PedidoView> ListaPersonalizada { get; set; }

        // Lista completa de Modelos
        public static List<Modelo> ListaModelos { get; internal set; }

        // Lista completa de Productos
        public static List<Producto> ListaProductos { get; set; }



        // indices de combobox y selecciones? / revisar
        public static int cbModelosSelectedIndex { get; set; }
        public static int cbProductosSelectedIndex { get;  set; }
        public static int dgPedidosSelectedIndex { get; set; }
        public static int cbFiltrosIndex { get; set; }

        public static string FiltroSeleccionado { get; set; } = "INGRESADO";

        public static Pedido NewOrder { get; set; }
        public static Pedido OldOrder { get; set; }

    }
}