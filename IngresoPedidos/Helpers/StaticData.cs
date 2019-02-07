using IngresoPedidos.DataAccessLayer;
using System.Collections.Generic;

namespace IngresoPedidos
{
    internal static class StaticData
    {
        public static DBContext context = new DBContext(); 

        public static Usuario Usuario { get; internal set; }
        public static List<PermisosView> ListaPermisos { get; internal set; }

        public static List<PedidoView> SearchList { get; internal set; }
        public static List<PedidoView> CustomList { get; internal set; }
        public static List<PedidoView> MainList { get; internal set; }

        public static Pedido NewOrder { get; internal set; }
        public static Pedido OldOrder { get; internal set; }

        public static List<Modelo> ModelsList { get; internal set; }
        public static List<Producto> ProductsList { get; internal set; }

        public static int cbModelosSelectedIndex { get; internal set; }
        public static int cbProductosSelectedIndex { get; internal set; }
        public static int dgPedidosSelectedIndex { get; internal set; }
        public static int cbFiltrosIndex { get; internal set; }
        public static string ServerName { get ; internal set; }

        public static string casa = "data source=DESKTOP;initial catalog=PRODUCCION;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        public static string exo = "data source=VM-FORREST;initial catalog=PRODUCCION;persist security info=True;user id=FORREST;password=12345678;MultipleActiveResultSets=True;App=EntityFramework";

    }
}