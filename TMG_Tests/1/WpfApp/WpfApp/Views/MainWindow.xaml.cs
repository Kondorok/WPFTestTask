using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp.Extensions;
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
            DataContext = new ApplicationViewModel(); //Using ViewModel as DataContext
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Window window = sender as Window;
            TextColumn.Width = window.Width / 2;
            WordsCountColumn.Width = window.Width / 5;
            VowelsCountColumn.Width = window.Width / 5;
        }
    }
}
