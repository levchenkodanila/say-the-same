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

        public void PerformRequest(Message message)
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

            stream?.Write(data, 0, data.Length);
        }

        public Task BeginMessageLoop()
        {
            return Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        Message received = ReadMessage();
                        MainForm? mf = CurrentForm as MainForm;
                        if (mf != null) mf.Invoke(() => { mf.OnMessageReceived(received); });
                        else throw new NullReferenceException();
                    }
                }
                catch (Exception ex)
                {
                    CurrentForm.Invoke(() =>
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                        CurrentForm.Close();
                    });
                }

            });
        }

        private Message ReadMessage()
        {
            if (stream != null)
            {
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
            else throw new NullReferenceException();
        }
    }
}
