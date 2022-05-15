using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace SayTheSame
{
    public partial class Server
    {
        private Task BeginClientLoop()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Начат приём входящих подключений.");
                try
                {
                    while(true)
                    {
                        Player player = new Player(TcpListener.AcceptTcpClient());
                        lock (Players) Players.Add(player);
                        BeginMessageLoop(player);
                        Console.WriteLine("Игрок подключен.");
                    }
                }
                catch
                {
                    Console.WriteLine("Приём входящих подключений остановлен.");
                }
            });
        }

        private Task BeginMessageLoop(Player target)
        {
            return Task.Run(() =>
            {
                try
                {
                    while(true)
                    {
                        Message message = ReadNextMessage(target);
                        MessageHandle(target, message);
                    }
                }
                catch
                {
                    target.Stream.Close();
                    target.TcpClient.Close();
                    Console.WriteLine($"Игрок {target.Nickname} отключен.");
                    lock (Players) Players.Remove(target);
                    if (target.Room != null)
                    {
                        Player opponent;
                        if (target.Room.Creator == target) opponent = target.Room.Invited;
                        else opponent = target.Room.Creator;
                        Message room_cancel = new Message(MessageType.ServerRoomCanceled, "");
                        BeginSendMessage(opponent, room_cancel);
                        opponent.Room = null;
                    }
                    foreach (Player adresee in Players)
                    {
                        Message list = new Message(MessageType.ServerPlayerList, BuildPlayerList(adresee));
                        BeginSendMessage(adresee, list);
                    }
                    foreach (Player pl in target.IncomingInvites)
                    {
                        Message invite_cancel = new Message(MessageType.ServerInviteRemoved, target.Nickname);
                        BeginSendMessage(pl, invite_cancel);
                    }
                }
            });
        }

        private void MessageHandle(Player sender, Message message)
        {
            if (message.Type == MessageType.ClientNickname)
            {
                string nickname = message.Payload;
                if (CheckNickname(nickname))
                {
                    Console.WriteLine($"Игрок установил никнейм {nickname}");
                    sender.Nickname = nickname;

                    Message accept = new Message(MessageType.ServerAccept, "");
                    BeginSendMessage(sender, accept);
                }
                else
                {
                    Message reject = new Message(MessageType.ServerReject, "");
                    BeginSendMessage(sender, reject);
                }
                foreach (Player adresee in Players)
                {
                    Message list = new Message(MessageType.ServerPlayerList, BuildPlayerList(adresee));
                    BeginSendMessage(adresee, list);
                }
            }

            if (message.Type == MessageType.ClientCreateInvite)
            {
                string nickname = message.Payload;
                Player? invited = Players.Find(p => p.Nickname == nickname);
                if (invited != null &&
                    invited != sender &&
                    invited.Room == null &&
                    !invited.IncomingInvites.Contains(sender))
                {
                    lock (invited.IncomingInvites) invited.IncomingInvites.Add(sender);
                    Message notification = new Message(MessageType.ServerInviteCreated, sender.Nickname);
                    BeginSendMessage(invited, notification);
                    Message accept = new Message(MessageType.ServerAccept, "");
                    BeginSendMessage(sender, accept);
                }
                else
                {
                    Message reject = new Message(MessageType.ServerReject, "");
                    BeginSendMessage(sender, reject);
                }
            }

            if (message.Type == MessageType.ClientInviteAccept)
            {
                string nickname = message.Payload;
                Player? invitor = Players.Find(p => p.Nickname == nickname);
                if (invitor != null && invitor != sender &&
                    invitor.Room == null && sender.Room == null &&
                    sender.IncomingInvites.Contains(invitor))
                {
                    lock (invitor) lock (sender)
                        {
                            Message accept = new Message(MessageType.ServerAccept, "");
                            BeginSendMessage(sender, accept);

                            foreach (Player target in invitor.IncomingInvites)
                            {
                                Message invite_cancel = new Message(MessageType.ServerInviteRemoved, invitor.Nickname);
                                BeginSendMessage(target, invite_cancel);
                            }
                            foreach (Player p in sender.IncomingInvites)
                            {
                                Message invite_cancel = new Message(MessageType.ServerInviteRemoved, sender.Nickname);
                                BeginSendMessage(sender, invite_cancel);
                            }

                            lock (invitor.IncomingInvites) invitor.IncomingInvites.Clear();
                            lock (sender.IncomingInvites) sender.IncomingInvites.Clear();

                            Room room = new Room(invitor, sender);
                            invitor.Room = room;
                            sender.Room = room;

                            Message invitor_notification = new Message(MessageType.ServerRoomEngagement, sender.Nickname);
                            Message sender_notification = new Message(MessageType.ServerRoomEngagement, invitor.Nickname);
                            BeginSendMessage(sender, sender_notification);
                            BeginSendMessage(invitor, invitor_notification);
                        }
                }
                else
                {
                    Message reject = new Message(MessageType.ServerReject, "");
                    BeginSendMessage(sender, reject);
                }
            }

            if (message.Type == MessageType.ClientInviteReject)
            {
                string nickname = message.Payload;
                Player? invitor = Players.Find(p => p.Nickname == nickname);
                if (invitor != null &&
                    invitor != sender &&
                    sender.IncomingInvites.Contains(invitor))
                {
                    lock (invitor.IncomingInvites) sender.IncomingInvites.Remove(invitor);

                    Message notification = new Message(MessageType.ServerInviteRemoved, sender.Nickname);
                    BeginSendMessage(invitor, notification);

                    Message accept = new Message(MessageType.ServerAccept, "");
                    BeginSendMessage(sender, accept);
                }
                else
                {
                    Message reject = new Message(MessageType.ServerReject, "");
                    BeginSendMessage(sender, reject);
                }
            }

            if (message.Type == MessageType.ClientRoomLeave)
            {
                if (sender.Room != null)
                {
                    Room room = sender.Room;

                    Player opponent;
                    if (room.Creator == sender) opponent = room.Invited;
                    else opponent = room.Creator;

                    opponent.Room = null;
                    sender.Room = null;

                    Message notify = new Message(MessageType.ServerRoomCanceled, "");
                    BeginSendMessage(opponent, notify);

                    Message accept = new Message(MessageType.ServerAccept, "");
                    BeginSendMessage(sender, accept);
                }
                else
                {
                    Message reject = new Message(MessageType.ServerReject, "");
                    BeginSendMessage(sender, reject);
                }
            }

            if (message.Type == MessageType.ClientGameWord)
            {
                Room? room = sender.Room;
                string received = message.Payload.Replace('ё', 'е').ToLower();

                if (room != null && room.CheckGameword(received) && room.WordSender != sender)
                {
                    Player opponent;
                    if (room.Creator == sender) opponent = room.Invited;
                    else opponent = room.Creator;

                    Message accept = new Message(MessageType.ServerAccept, "");
                    BeginSendMessage(sender, accept);

                    lock (room)
                    {
                        if (room.Word == null)
                        {
                            room.Word = received;
                            room.WordSender = sender;

                            Message reminder = new Message(MessageType.ServerGameReminder, "");
                            BeginSendMessage(opponent, reminder);
                        }
                        else
                        {
                            string word1 = room.Word;
                            string word2 = received;
                            room.Word = null;
                            room.WordSender = null;

                            Message out_notify = new Message(MessageType.ServerGameWordsOut, $"{word1} {word2}");
                            BeginSendMessage(sender, out_notify);
                            BeginSendMessage(opponent, out_notify);

                            if (word1 == word2)
                            {
                                room.PlayedOutWords.Clear();

                                Message finish_notify = new Message(MessageType.ServerGameFinished, "");
                                BeginSendMessage(sender, finish_notify);
                                BeginSendMessage(opponent, finish_notify);
                            }
                            else
                            {
                                room.PlayedOutWords.Add(word1);
                                room.PlayedOutWords.Add(word2);
                            }
                        }
                    }
                }
                else
                {
                    Message reject = new Message(MessageType.ServerReject, "");
                    BeginSendMessage(sender, reject);
                }

            }

            if (message.Type == MessageType.ClientGlobalChat)
            {
                string words = message.Payload;

                if (CheckChatMessage(words))
                {
                    Message accept = new Message(MessageType.ServerAccept, "");
                    BeginSendMessage(sender, accept);

                    foreach (Player p in Players)
                    {
                        Message chat_notify = new Message(MessageType.ServerGlobalChat, $"[{sender.Nickname}]: {words}");
                        BeginSendMessage(p, chat_notify);
                    }
                }
                else
                {
                    Message reject = new Message(MessageType.ServerReject, "");
                    BeginSendMessage(sender, reject);
                }
            }

            if (message.Type == MessageType.ClientRoomChat)
            {
                string words = message.Payload;
                Room? room = sender.Room;

                if (CheckChatMessage(words) && room != null)
                {
                    Message accept = new Message(MessageType.ServerAccept, "");
                    BeginSendMessage(sender, accept);

                    Message chat_notify = new Message(MessageType.ServerRoomChat, $"[{sender.Nickname}]: {words}");
                    BeginSendMessage(room.Invited, chat_notify);
                    BeginSendMessage(room.Creator, chat_notify);
                }
                else
                {
                    Message reject = new Message(MessageType.ServerReject, "");
                    BeginSendMessage(sender, reject);
                }
            }

            if (message.Type == MessageType.ClientPlayerList)
            {
                string list = BuildPlayerList(sender);
                Message listupdate = new Message(MessageType.ServerPlayerList, list);
                BeginSendMessage(sender, listupdate);
            }
        }

        private string BuildPlayerList(Player picked_out)
        {
            StringBuilder list = new StringBuilder();
            foreach (Player p in Players)
            {
                if (p == picked_out)
                {
                    list.Append('^');
                }
                else
                {
                    if (p.Room == null) list.Append('?');
                    else list.Append('!');
                }
                list.Append(p.Nickname + ' ');
            }
            return list.ToString();
        }

        private Task BeginSendMessage(Player adresee, Message message)
        {
            return Task.Run(() =>
            {
                try
                {  
                    byte[] data = new byte[message.Payload.Length * 2 + 3];

                    data[0] = (byte)message.Type;

                    byte[] length_bytes = BitConverter.GetBytes((UInt16)message.Payload.Length);
                    data[1] = length_bytes[0];
                    data[2] = length_bytes[1];

                    for (int i = 0; i < message.Payload.Length; i++)
                    {
                        byte[] payload_part = BitConverter.GetBytes(message.Payload[i]);
                        data[i * 2 + 3] = payload_part[0];
                        data[i * 2 + 4] = payload_part[1];
                    }

                    lock (adresee) adresee.Stream.Write(data, 0, data.Length);
                }
                catch
                {
                    Console.WriteLine("Не удалось отправить данные.");
                }
            });
        }

        private Message ReadNextMessage(Player target)
        {
            NetworkStream stream = target.Stream;

            MessageType type = (MessageType)stream.ReadByte();

            byte[] length_bytes = new byte[2];
            stream.Read(length_bytes, 0, 2);
            UInt16 length = BitConverter.ToUInt16(length_bytes, 0);

            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                byte[] payload_part = new byte[2];
                stream.Read(payload_part, 0, 2);
                sb.Append(BitConverter.ToChar(payload_part, 0));
            }
            string payload = sb.ToString();

            return new Message(type, payload);
        }
    }
}
