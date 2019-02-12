using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows;

namespace IngresoPedidos.Helpers
{
    public static class ConnectionCheck
    {
        public static bool Success(string hostNameOrIPAddress)
        {
            using (new WaitCursor())
            {
                try
                {
                    Ping pingSender = new Ping();
                    PingReply reply;
                    IPAddress[] ip = Dns.GetHostAddresses(hostNameOrIPAddress);
                    reply = pingSender.Send(ip[0]);

                    if (reply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo contactar al servidor.", "Conexión a sevidor", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("No se especificó un nombre ó direccion IP de servidor", "Conexión a sevidor", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                catch (SocketException)
                {
                    MessageBox.Show("No se encontró el servidor " + hostNameOrIPAddress + ".", "Conexión a sevidor", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

            }

        }
    }
}
