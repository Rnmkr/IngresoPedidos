using System.Windows.Input;

namespace IngresoPedidos.Helpers
{
    static class CustomCommands
    {
        public static RoutedCommand nuevoPedidoCommand = new RoutedCommand();
        public static RoutedCommand exportarXLSCommand = new RoutedCommand();
        public static RoutedCommand buscarPedidoCommand = new RoutedCommand();
        public static RoutedCommand filtrarListaCommand = new RoutedCommand();
        public static RoutedCommand editarPedidoCommand = new RoutedCommand();
        public static RoutedCommand agregarPeronalizadaCommand = new RoutedCommand();
        public static RoutedCommand quitarPersonalizadaCommand = new RoutedCommand();
        public static RoutedCommand verRegistroEventosCommand = new RoutedCommand();
        public static RoutedCommand verImagenProductoCommand = new RoutedCommand();
        public static RoutedCommand agregarObservacionCommand = new RoutedCommand();
        public static RoutedCommand generarPlanillaCommand = new RoutedCommand();
    }
}