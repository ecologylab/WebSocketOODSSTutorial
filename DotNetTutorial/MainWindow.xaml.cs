using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;
using WebSocketOODSSTutorial.Chat;

namespace WebSocketOODSSTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChatClient _chatClient;

        public MainWindow()
        {
            InitializeComponent();
            _chatClient = new ChatClient();
            _chatClient.StartConnection();
            _chatClient.Updated += new EventHandler(UpdateReceivedMessage);
        }

        private void OnSendButtonClicked(object sender, RoutedEventArgs e)
        {
            _chatClient.SendMessage(InputTextBox.Text);
            UpdateDisplay();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && InputTextBox.Text!="")
            {
                _chatClient.SendMessage(InputTextBox.Text);
                UpdateDisplay();
            }
        }

        public void UpdateReceivedMessage(object sender, EventArgs e)
        {
            UpdateEventArgs ue = (UpdateEventArgs) e;
            string s = ue.Id + " -> " + ue.Message + "\n\n";
            DisplayBox.Dispatcher.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.Normal,
                new DispatcherOperationCallback(delegate
                                                    {
                                                        DisplayBox.Text += s;
                                                        DisplayBox.ScrollToEnd();
                                                        return null;
                                                    }), null);
            //DisplayBox.Text = s;
            //DisplayBox.ScrollToEnd();
        }

        private void UpdateDisplay()
        {
            String input = InputTextBox.Text;
            DisplayBox.Text = DisplayBox.Text + input + "\n\n";
            DisplayBox.ScrollToEnd();
            InputTextBox.Clear();
        }
    }
}
