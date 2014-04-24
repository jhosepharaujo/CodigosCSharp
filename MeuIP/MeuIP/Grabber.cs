using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace MeuIP
{
    class Grabber
    {
        public string Ip { get; private set; }
        public string Hostname { get; private set; }

        public Grabber()
        {
            ConfigureInfoNetwork();
        }

        private void ConfigureInfoNetwork()
        {
            Hostname = Dns.GetHostName();
            
            IPHostEntry entry = Dns.GetHostEntry(Hostname);
            IPAddress ip = entry.AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
            Ip = ip.ToString();
        }
    }
}
