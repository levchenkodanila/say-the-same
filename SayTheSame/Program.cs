using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SayTheSame
{
    public static class Program
    {
        public static bool Server = false;

        public static void Main(string[] args)
        {
            Server = args.Contains("-server");
            if (!Server)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.SetHighDpiMode(HighDpiMode.SystemAware);

                Client client = new Client();

                Application.Run(client.CurrentForm);
                if (client.TcpClient.Connected) Application.Run(client.CurrentForm);

                Application.Exit();
            }
            if(Server)
            {
                AllocConsole();
                Server server = new Server();
                server.Run();
                Console.ReadLine();
                server.Stop();
                Console.ReadLine();
            }
        }


        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
    }
}
