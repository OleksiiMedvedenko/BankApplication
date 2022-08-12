using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrehPL.Tools.Interactions
{
    public static class Popup
    {
        public static void Error(string title, string prefix, Exception e)
        {
            var builder = new StringBuilder();

            builder.AppendLine(prefix);
            builder.AppendLine(MessageBuilder.ErrorMessage(e));

            MessageBox.Show(builder.ToString(), title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void Error(string title, string message) => MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);

        public static MessageBoxResult ErrorWithDecision(string title, string prefix, Exception e)
        {
            var builder = new StringBuilder();

            builder.AppendLine(prefix);
            builder.AppendLine(MessageBuilder.ErrorMessage(e));

            var result = MessageBox.Show(builder.ToString(), title, MessageBoxButton.YesNo, MessageBoxImage.Error);

            return result;
        }

        public static MessageBoxResult ErrorWithDecision(string title, string message)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Error);

            return result;
        }

        public static void Information(string title, string message) => MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);

        public static MessageBoxResult InformationWithDecision(string title, string message)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Information);

            return result;
        }

        public static void Warning(string title, string message) => MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);

        public static MessageBoxResult WarningWithDecision(string title, string message)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            return result;
        }
    }
}
