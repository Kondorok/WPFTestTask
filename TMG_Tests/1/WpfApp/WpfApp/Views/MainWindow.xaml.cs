using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }

        private void TextBox_Changed(object sender, RoutedEventArgs e)
        { 
            TextBox x = (TextBox)sender;
            if (x.Text.Length>5)
            x.Foreground = Brushes.Red;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            button.IsEnabled = false;
            
            button.IsEnabled = true;
        }
    }
}
