using System;
using System.Net;
using System.Net.NetworkInformation;

namespace IngresoPedidos.Helpers
{
    class ConnectionCheck
    {
        public static bool IsServerOnline()
        {
            string hostName = "VM-FORREST";

            try
            {
                IPAddress[] ip = Dns.GetHostAddresses(hostName);
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(ip[0]);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
