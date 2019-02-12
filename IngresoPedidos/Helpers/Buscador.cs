using IngresoPedidos.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IngresoPedidos.Helpers
{
    class Buscador
    {
        DBContext context;

        public Buscador(DBContext databasecontext)
        {
            context = databasecontext;
        }

        public List<PedidoView> ObtenerPedidos(string keyword, string campo)
        {
            List<PedidoView> result = new List<PedidoView>();

            if (keyword == "*")
            {
                result = context.PedidoView.Select(s => s).ToList();
                return result;
            }

            switch (campo)
            {
                case "ID":
                    int id = Convert.ToInt32(keyword);
                    result = context.PedidoView.Where(w => w.IDPedido == id).Select(s => s).ToList();
                    return result;

                case "PEDIDO":
                    result = context.PedidoView.Where(w => w.NumeroPedido.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "MODELO":
                    result = context.PedidoView.Where(w => w.NombreModelo.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "PRODUCTO":
                    result = context.PedidoView.Where(w => w.NombreProducto.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "ARTICULO":
                    result = context.PedidoView.Where(w => w.NumeroArticulo.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "CANTIDAD":
                    int cantidad = Convert.ToInt32(keyword);
                    result = context.PedidoView.Where(w => w.CantidadEquipos == cantidad).Select(s => s).ToList();
                    return result;

                case "ESTADO":
                    result = context.PedidoView.Where(w => w.NombreEstado.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "ANTERIOR":
                    result = context.PedidoView.Where(w => w.NumeroPedidoAnterior.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "SUCESOR":
                    result = context.PedidoView.Where(w => w.NumeroPedidoSucesor.Contains(keyword)).Select(s => s).ToList();
                    return result;

                default:
                    Exception e = new Exception();
                    throw e;
            }
        }

        public List<PedidoView> ObtenerPedidos(string keyword, string campo, string campofecha, DateTime fechaInicial, DateTime fechaFinal)
        {
            List<PedidoView> result = new List<PedidoView>();

            if (fechaInicial == fechaFinal)
            {
                fechaInicial = fechaInicial.AddDays(-1);
                fechaFinal = fechaFinal.AddDays(1);
            }

            switch (campofecha)
            {
                case "FECHA INGRESO":
                    result = context.PedidoView.Where(w => w.FechaIngreso >= fechaInicial && w.FechaIngreso <= fechaFinal).Select(s => s).ToList();
                    break;

                case "FECHA ESTADO":
                    result = context.PedidoView.Where(w => w.FechaEstado >= fechaInicial && w.FechaEstado <= fechaFinal).Select(s => s).ToList();
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
                    result = result.Where(w => w.NumeroArticulo.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "CANTIDAD":
                    int cantidad = Convert.ToInt32(keyword);
                    result = result.Where(w => w.CantidadEquipos == cantidad).Select(s => s).ToList();
                    return result;

                case "ESTADO":
                    result = result.Where(w => w.NombreEstado.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "ANTERIOR":
                    result = result.Where(w => w.NumeroPedidoAnterior.Contains(keyword)).Select(s => s).ToList();
                    return result;

                case "SUCESOR":
                    result = result.Where(w => w.NumeroPedidoSucesor.Contains(keyword)).Select(s => s).ToList();
                    return result;

                default:
                    Exception e = new Exception();
                    throw e;
            }
        }
    }
}


