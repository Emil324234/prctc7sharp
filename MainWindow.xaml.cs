using prct7csharp;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace messenger_prct
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void createChat_Click(object sender, RoutedEventArgs e)
        {
            if (userName.Text != string.Empty)
            {
                AdminWindow admin = new AdminWindow();
                Close();
                admin.Show();
            }
            else
            {
                MessageBox.Show("Необходимо ввести имя пользователя.", "Пустое текстовое поле!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void connectChat_Click(object sender, RoutedEventArgs e)
        {
            if (ipAD.Text == "26.233.141.179" && userName.Text != string.Empty)
            {
                UserWindow user = new UserWindow();
                Close();
                user.Show();
            }
            else if (ipAD.Text != "26.233.141.179" && userName.Text != string.Empty)
            {
                MessageBox.Show("Такого чата не существует.", "Неверный IP адрес!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (ipAD.Text == string.Empty || userName.Text == string.Empty)
            {
                MessageBox.Show("Необходимо заполнить все поля.", "Пустое текстовое поле!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}