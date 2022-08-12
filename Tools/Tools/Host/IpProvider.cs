using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.Host
{
    public class IpProvider
    {
        public static string GetIpStation()
        {
            //string result = "172.18.62.34";

            string result = string.Empty;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork && !ip.ToString().StartsWith("192."))
                {
                    result = ip.ToString();
                }
            }
            return result;
        }
    }
}
