using Avalonia.Controls;
using BlackJack.Model;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using Views;

namespace BlackJack.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenSettings(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var settings = new SettingsWindow();
            settings.Show();
        }
    }
}