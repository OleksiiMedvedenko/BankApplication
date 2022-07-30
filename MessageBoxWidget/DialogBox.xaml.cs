using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using MessageBoxWidget.Model;

namespace MessageBoxWidget
{
    /// <summary>
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        private static int Quantity { get; set; }
        private static string Position { get; set; }
        private static bool ValueOfDialogBox { get; set; }
        public DialogBox()
        {
            InitializeComponent();
        }

        public static (int quantity, string position, bool valueOfDialogBox) ShowDialogBox()
        {
            new DialogBox().ShowDialog();

            return (Quantity, Position, ValueOfDialogBox);
        }

        private void Denied_ButtonClick(object sender, RoutedEventArgs e)
        {
            ValueOfDialogBox = false;
            this.DialogResult = false;
            this.Close();
        }
        private void Accept_ButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            ValueOfDialogBox = true;
            if (!string.IsNullOrEmpty(QuantityTextBox.Text))
            {
                Quantity = int.Parse(QuantityTextBox.Text);
            }

            Position = PositionTextBox.Text;

            this.Close();
        }
        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
