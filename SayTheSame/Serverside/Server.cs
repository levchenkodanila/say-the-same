using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace SayTheSame
{
    public partial class Server
    {

        public static readonly Int32 TCP_PORT = 25732;

        private List<Player> Players = new List<Player>();

        private TcpListener TcpListener = new TcpListener(IPAddress.Any, TCP_PORT);

        public void Run() 
        {
            Console.WriteLine("Сервер запускается...");
            TcpListener.Start();
            BeginClientLoop();
        }

        public void Stop()
        {
            Console.WriteLine("Сервер отключается...");
            foreach(Player player in Players)
            {
                player.Stream.Close();
                player.TcpClient.Close();
            }
            TcpListener.Stop();
        }

        private class Player
        {
            public NetworkStream Stream;
            public TcpClient TcpClient;
            public Player(TcpClient tcpclient)
            {
                TcpClient = tcpclient;
                Stream = tcpclient.GetStream();

                Random random = new Random();
                Nickname = "Player" + random.Next(100, 999).ToString();
            }

            public List<Player> IncomingInvites = new List<Player>();

            public string Nickname;
            public Room? Room = null;
        }

        private class Room
        {
            public Player Creator;
            public Player Invited;

            public List<string> PlayedOutWords = new List<string>();

            public Player? WordSender = null;
            public string? Word = null;

            public Room(Player creator, Player invited)
            {
                Creator = creator;
                Invited = invited;
            }

            public bool CheckGameword(string word)
            {
                string cyrillic_consonants = "бвгджзйклмнпрстфхцчшщъь";
                string cyrillic_vowels = "аеиоуыэюя";

                if (word.Length >= 3 && !PlayedOutWords.Contains(word) && word.Length <= 30)
                {
                    int consonants_count = 0;
                    int vowels_count = 0;
                    foreach (char c in word)
                    {
                        if (cyrillic_vowels.Contains(c)) vowels_count++;
                        if (cyrillic_consonants.Contains(c)) consonants_count++;
                    }
                    if (consonants_count > 0 &&
                        vowels_count > 0 &&
                        word.Length == consonants_count + vowels_count) return true;
                    else return false;
                }
                else return false;
            }

        }

        private bool CheckChatMessage(string message)
        {
            return message.Length <= 500;
        }

        private bool CheckNickname(string nickname)
        {
            return Regex.IsMatch(nickname, @"^[\w\d]{3,15}$") && Players.Find(p => p.Nickname == nickname) == null;
        }

    }
}
