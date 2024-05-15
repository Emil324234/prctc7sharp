using prct7csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace messenger_prct.ClientServer
{
    internal class TcpServer
    {
        public static async void ListenToClients(Socket socket, List<Socket> users)
        {
            while (true)
            {
                var client = await socket.AcceptAsync();
                users.Add(client);
                ReceiveMessage(client, users);
            }
        }

        private static async void ReceiveMessage(Socket c, List<Socket> users)
        {
            AdminWindow admin = new AdminWindow();
            while (true)
            {
                byte[] zeroes = new byte[65536];
                await c.ReceiveAsync(zeroes);
                string message = Encoding.UTF8.GetString(zeroes);

                admin.messages.Items.Add(message);

                foreach (var item in users)
                {
                    SendMessage(message, item);
                }
            }
        }

        public static async void SendMessage(string message, Socket c)
        {
            byte[] zeroes = Encoding.UTF8.GetBytes(message);
            await c.SendAsync(zeroes);
        }
    }
}
