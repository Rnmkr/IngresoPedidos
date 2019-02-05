using IngresoPedidos.Models;
using System.Collections.Generic;

namespace IngresoPedidos
{
    internal static class StaticData
    {
        public static DataBaseContext context = new DataBaseContext(); 

        public static Usuario Usuario { get; internal set; }
        public static List<Permisos> ListaPermisos { get; internal set; }

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

    }
}