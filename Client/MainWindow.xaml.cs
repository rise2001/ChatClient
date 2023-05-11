using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChatClient chatClient;
        EncryptionService encryptionService;

        public MainWindow()
        {
            InitializeComponent();
            chatClient = new ChatClient(SetRecievedText);
            encryptionService = new EncryptionService();


            SendButton.IsEnabled = false;
            InputTextBox.IsEnabled = false;
            MainTextBox.IsEnabled = false;
        }

        private void InOutButton_Click(object sender, RoutedEventArgs e)
        {
            var ip = IPTextBox.Text;
            var port = int.Parse(PortTextBox.Text);
            if (chatClient.Connect(ip, port))
            {
                SendButton.IsEnabled = true;
                InputTextBox.IsEnabled = true;
                MainTextBox.IsEnabled = true;

                KeyTextBox.IsEnabled = false;
                NameTextBox.IsEnabled = false;
                IPTextBox.IsEnabled = false;
                PortTextBox.IsEnabled = false;
                InOutButton.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Ошибка при подключении к серверу");
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            var text = InputTextBox.Text;
            var name = NameTextBox.Text;
            var key = KeyTextBox.Text;
            var textBytes = Encoding.UTF8.GetBytes(text);
            var nameBytes = Encoding.UTF8.GetBytes(name);
            var encryptedText = encryptionService.Encrypt(key, text);

            byte[] data = new byte[600];
            Array.Copy(nameBytes, data, nameBytes.Length < 68 ? nameBytes.Length : 68);
            Array.Copy(BitConverter.GetBytes(encryptedText.Length), 0, data, 68, 4);
            Array.Copy(encryptedText, 0, data, 72, encryptedText.Length);

            chatClient.SendMessage(data);
        }

        private void SetRecievedText(byte[] data)
        {
            byte[] name = new byte[16];
            byte[] size = new byte[4];

            Array.Copy(data, 0, name, 0, 16);
            Array.Copy(data, 68, size, 0, 4);
            var nameString = Encoding.UTF8.GetString(name);

            int sizeOfEncryptedText = BitConverter.ToInt32(size, 0);

            byte[] encryptedBytes = new byte[sizeOfEncryptedText];
            Array.Copy(data, 72, encryptedBytes, 0, sizeOfEncryptedText);

            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => {
                try
                {
                    var key = KeyTextBox.Text;
                    var decryptedText = encryptionService.Decrypt(key, encryptedBytes);
                    MainTextBox.Text = MainTextBox.Text + "\n" + nameString + " : " + decryptedText;
                }
                catch
                {
                    MessageBox.Show("Ошибка при дешифровке");
                }
            }));
        }

    }
}
