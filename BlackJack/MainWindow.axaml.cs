using Avalonia.Controls;
using Microsoft.VisualBasic;
using Views;

namespace BlackJack
{
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();
        public MainWindow()
        {
            InitializeComponent();
            Card card = new Card(1, 2);
            string test = "&#xe270;";
            char icon = '\ueb9a';
            this.DataContext = icon;
        }

        private void OpenSettings(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var settings = new SettingsWindow();
            settings.Show();
        }
    }
}