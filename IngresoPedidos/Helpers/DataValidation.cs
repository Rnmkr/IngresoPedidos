﻿using IngresoPedidos.DataAccessLayer;
using System.Text.RegularExpressions;

namespace IngresoPedidos.Helpers
{
    class DataValidation
    {
        public bool ValidarPedido(PedidoView pedido)
        {

            Regex regexPedido = new Regex(@"^\d{7}[a-cA-C]-\d{2}$");
            Regex regexSoloNumeros = new Regex("^[0-9]+$");
            Regex regexCantidad = new Regex("^[0-9]+$");

        bool pedidoValido = regexPedido.IsMatch(pedido.NumeroPedido);
            bool articuloValido = regexSoloNumeros.IsMatch(pedido.NumeroArticulo);
            bool anteriorValido = regexPedido.IsMatch(pedido.NumeroPedidoAnterior);
            bool cantidadValida = regexSoloNumeros.IsMatch(pedido.CantidadEquipos.ToString());

            if (!pedidoValido)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(pedido.NombreModelo))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(pedido.NombreProducto))
            {
                return false;
            }

            if (!articuloValido)
            {
                return false;
            }

            if (!cantidadValida)
            {
                return false;
            }

            if (!anteriorValido)
            {
                return false;
            }

            return false;
        }
    }
}
