using MessageBoxWidget.Model;
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
using System.Windows.Shapes;

namespace MessageBoxWidget
{
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string messageFromApplication, MessageType messageType)
        {
            InitializeComponent();
            MessageFromApplication.Text = messageFromApplication;
            ChoiceMessageType(messageType);
        }

        public CustomMessageBox(Exception ex, MessageType messageType)
        {
            InitializeComponent();
            MessageFromApplication.Text = ex.Message;
            MessageFromApplication.ToolTip = ex.ToString();
            ChoiceMessageType(messageType);
        }


        public static bool Show(MessageType messageType, string message = null, Exception exception = null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                return new CustomMessageBox(message, messageType).ShowDialog().Value;
            }
            return new CustomMessageBox(exception, messageType).ShowDialog().Value;
        }

        private void ChoiceMessageType(MessageType messageType)
        {
            switch (messageType)
            {
                case Model.MessageType.Confirmation:
                    {
                        Color bkColor = (Color)ColorConverter.ConvertFromString("#4b008f");
                        ChangeBackGroundButtonAndHeaderColor(bkColor);
                        MessageType.Text = "Confirmation";
                    }
                    break;
                case Model.MessageType.Success:
                    {
                        ChangeBackGroundButtonAndHeaderColor(Colors.Green);
                        MessageType.Text = "Success";
                    }
                    break;
                case Model.MessageType.Error:
                    {
                        ChangeBackGroundButtonAndHeaderColor(Colors.Red);
                        MessageType.Text = "Error";
                    }
                    break;
                case Model.MessageType.NotFound:
                    {
                        ChangeBackGroundButtonAndHeaderColor(Colors.Red);
                        MessageType.Text = "Not Found";
                    }
                    break;
                case Model.MessageType.Warning:
                    {
                        ChangeBackGroundButtonAndHeaderColor(Colors.DarkOrange);
                        MessageType.Text = "Warning";
                    }
                    break;
                default:
                    {
                        MessageType.Text = "Message";
                    }
                    break;
            }
        }
        private void Denied_ButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Accept_ButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void ChangeBackGroundButtonAndHeaderColor(Color newColor)
        {
            CardHeader.Background = new SolidColorBrush(newColor);

            AcceptButton.Background = new SolidColorBrush(newColor);
            DeniedButton.Background = new SolidColorBrush(newColor);
        }

        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

    }
}
