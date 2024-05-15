using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms; 

namespace prct7csharp.ClientServer
{
    internal class TcpClient
    {
        public static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static async Task ConnectToServer(string ipAddress, int port)
        {
            await clientSocket.ConnectAsync(ipAddress, port);
            MessageBox.Show("Соединение"); 
            Task.Run(() => ReceiveMessages());
        }

        public static async void ReceiveMessages()
        {
            while (true)
            {
                byte[] buffer = new byte[65536];
                int received = await clientSocket.ReceiveAsync(buffer, SocketFlags.None);
                if (received == 0)
                {
                    break;
                }
                string message = Encoding.UTF8.GetString(buffer, 0, received);
                MessageBox.Show("Received message: " + message); 
            }
        }

        public static async Task SendMessage(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            await clientSocket.SendAsync(buffer, SocketFlags.None);
            MessageBox.Show("Sent message: " + message);
        }
    }
}
