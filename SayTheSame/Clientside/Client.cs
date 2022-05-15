using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SayTheSame
{
    public partial class Client
    {
        private static Client? current;
        public static Client GetClient()
        {
            if (current != null) return current;
            else throw new NullReferenceException();
        }

        public Form CurrentForm;
        public TcpClient TcpClient;

        public string GetServerIP()
        {
            if(TcpClient.Client.RemoteEndPoint != null)
            {
                return ((IPEndPoint)TcpClient.Client.RemoteEndPoint).Address.MapToIPv4().ToString();
            }
            else throw new InvalidOperationException();
        }

        public Client()
        {
            TcpClient = new TcpClient();
            CurrentForm = new ConnectionForm();
            current = this;
        }

        private NetworkStream? stream;
        public void Connect(IPAddress ip)
        {
            TcpClient.Connect(ip, Server.TCP_PORT);
            stream = TcpClient.GetStream();
        }
    }
}
