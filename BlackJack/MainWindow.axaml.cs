using Avalonia.Controls;
using Microsoft.VisualBasic;

namespace BlackJack
{
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();
        public MainWindow()
        {
            InitializeComponent();
            //string test = "&x#e270;";
            DataContext = this;
        }

        private void OpenSettings(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }
    }
}