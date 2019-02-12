using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows;

namespace IngresoPedidos.Helpers
{
    public static class ConnectionCheck
    {
        static string serverHostName = StaticData.ServerHostName;

        public static bool Success()
        {
            try
            {
                IPAddress[] ip = Dns.GetHostAddresses(serverHostName);
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(ip[0]);

                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("No se pudo contactar al servidor");
                    return false;
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("No se especificó un nombre de servidor.", "INGRESO DE PEDIDOS", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            catch (SocketException)
            {
                MessageBox.Show("No se encontró un servidor con nombre " + serverHostName + ".", "INGRESO DE PEDIDOS", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }
    }
}
