﻿using IngresoPedidos.DataAccessLayer;
using System.Collections.Generic;

namespace IngresoPedidos
{
    internal static class StaticData
    {
        public static Context context = new Context(); 

        public static Usuarios Usuario { get; internal set; }
        public static List<PermisosView> ListaPermisos { get; internal set; }

        public static List<PedidosView> SearchList { get; internal set; }
        public static List<PedidosView> CustomList { get; internal set; }
        public static List<PedidosView> MainList { get; internal set; }

        public static Pedidos NewOrder { get; internal set; }
        public static Pedidos OldOrder { get; internal set; }

        public static List<Modelos> ModelsList { get; internal set; }
        public static List<Productos> ProductsList { get; internal set; }

        public static int cbModelosSelectedIndex { get; internal set; }
        public static int cbProductosSelectedIndex { get; internal set; }
        public static int dgPedidosSelectedIndex { get; internal set; }
        public static int cbFiltrosIndex { get; internal set; }
        public static string ServerName { get ; internal set; }

    }
}