using System.Windows;

namespace WpfApplication
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

        private void Send_Name(object sender, RoutedEventArgs e)
        {
            OutputLabel.Visibility = Visibility.Visible;

            if (string.IsNullOrEmpty(NameBox.Text))
            {
                OutputLabel.Content = "«Hello, unknown user!»";
            }
            else
            {
                OutputLabel.Content = $"«Hello, {NameBox.Text}!»";
            }
        }
    }
}
