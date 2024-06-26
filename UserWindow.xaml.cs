using messenger_prct;
using messenger_prct.ClientServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prct7csharp
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        List<Socket> users = new List<Socket>();
        Socket socket;

        MainWindow main = new MainWindow();
        public UserWindow()
        {
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect("26.80.234.197", 7000);
            TcpClient.ReceiveMessage();
        }
        void SendingMessage()
        {
            try
            {
                TcpClient.SendMessage(msg.Text, socket);
            }
            catch
            {
                MessageBox.Show("Не удается отправить сообщение!", "Случился сбой в сервере!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void ExitFromChat()
        {
            var result = MessageBox.Show("Если да, то вы покинете этот чат.", "Вы уверены?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Close();
                main.Show();
            }
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            if (msg.Text == "/disconnect")
            {
                ExitFromChat();
            }
            else if (msg.Text == string.Empty)
            {
                MessageBox.Show("Необходимо ввести сообщение.", "Пустое текстовое поле!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                SendingMessage();
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            ExitFromChat();
        }
    }
}
