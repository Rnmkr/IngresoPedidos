using IngresoPedidos.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IngresoPedidos.Helpers
{
    class Busqueda
    {
        Context context;

        public Busqueda(Context databasecontext)
        {
            context = databasecontext;
        }

        public List<PedidosView> ObtenerPedidos(string keyword, string campo)
        {
            List<PedidosView> result = new List<PedidosView>();

            if (keyword == "*")
            {
                result = context.PedidosView.Select(s => s).ToList();
                return result;
            }

            switch (campo)
            {
                case "ID":
                    int id = Convert.ToInt32(keyword);
                    result = context.PedidosView.Where(w => w.IDPedido == id).Select(s => s).ToList();
                    return result;

                case "PEDIDO":
                    result = context.PedidosView.Where(w => w.NumeroPedido.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "MODELO":
                    result = context.PedidosView.Where(w => w.NombreModelo.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "PRODUCTO":
                    result = context.PedidosView.Where(w => w.NombreProducto.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "ARTICULO":
                    result = context.PedidosView.Where(w => w.Articulo.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "CANTIDAD":
                    int cantidad = Convert.ToInt32(keyword);
                    result = context.PedidosView.Where(w => w.CantidadEquipos == cantidad).Select(s => s).ToList();
                    return result;

                case "ESTADO":
                    result = context.PedidosView.Where(w => w.EstadoPedido.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "ANTERIOR":
                    result = context.PedidosView.Where(w => w.PedidoAnterior.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "SUCESOR":
                    result = context.PedidosView.Where(w => w.PedidoSucesor.Contains(keyword)).Select(s => s).ToList();
                    return result;

                default:
                    Exception e = new Exception();
                    throw e;
            }
        }

        public List<PedidosView> ObtenerPedidos(string keyword, string campo, string campofecha, DateTime fechaInicio, DateTime fechaFinal)
        {
            List<PedidosView> result = new List<PedidosView>();

            switch (campofecha)
            {
                case "FECHA INGRESO":
                    result = context.PedidosView.Where(w => w.FechaIngreso >= fechaInicio && w.FechaIngreso <= fechaFinal).Select(s => s).ToList();
                    break;

                case "FECHA ESTADO":
                    result = context.PedidosView.Where(w => w.FechaEstado >= fechaInicio && w.FechaEstado <= fechaFinal).Select(s => s).ToList();
                    break;

                default:
                    Exception e = new Exception();
                    throw e;
            }

            if (keyword == "*")
            {
                return result;
            }

            switch (campo)
            {
                case "ID":
                    int id = Convert.ToInt32(keyword);
                    result = result.Where(w => w.IDPedido == id).Select(s => s).ToList();
                    return result;

                case "PEDIDO":
                    result = result.Where(w => w.NumeroPedido.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "MODELO":
                    result = result.Where(w => w.NombreModelo.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "PRODUCTO":
                    result = result.Where(w => w.NombreProducto.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "ARTICULO":
                    result = result.Where(w => w.Articulo.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "CANTIDAD":
                    int cantidad = Convert.ToInt32(keyword);
                    result = result.Where(w => w.CantidadEquipos == cantidad).Select(s => s).ToList();
                    return result;

                case "ESTADO":
                    result = result.Where(w => w.EstadoPedido.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "ANTERIOR":
                    result = result.Where(w => w.PedidoAnterior.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "SUCESOR":
                    result = result.Where(w => w.PedidoSucesor.Contains(keyword)).Select(s => s).ToList();
                    return result;

                default:
                    Exception e = new Exception();
                    throw e;
            }
        }

        public List<Modelos> ObtenerModelos()
        {
            List<Modelos> result = context.Modelos.Select(s => s).ToList();
            return result;
        }

        public List<Modelos> ObtenerModelos(string producto)
        {
            int? idproducto = context.Productos.Where(w => w.NombreProducto == producto).Select(s => s.IDProducto).SingleOrDefault();

            if (idproducto == null)
            {
                Exception e = new Exception();
                throw e;
            }

            List<Modelos> result = context.Modelos.Where(w => w.FK_IDProducto == idproducto).Select(s => s).ToList();
            return result;
        }

        public List<Productos> ObtenerProductos()
        {
            List<Productos> result = context.Productos.Select(s => s).ToList();
            return result;
        }

        public List<Productos> ObtenerProductos(string modelo)
        {
            int? fkidproducto = context.Modelos.Where(w => w.NombreModelo == modelo).Select(s => s.FK_IDProducto).SingleOrDefault();

            if (fkidproducto == null)
            {
                Exception e = new Exception();
                throw e;
            }

            List<Productos> result = context.Productos.Where(w => w.IDProducto == fkidproducto).Select(s => s).ToList();
            return result;
        }

        public Usuarios ObtenerUsuario(string legajo)
        {
            Usuarios result = context.Usuarios.Where(w => w.LegajoUsuario == legajo).SingleOrDefault();
            return result;
        }
    }
}
