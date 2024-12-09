using Avalonia.Controls;
using BlackJack.Views;
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
            Card card = deck.PickCard();
            CardViewControl.SetCardData(card.Value, card.Suit, card.Color);
        }

        private void OpenSettings(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var settings = new SettingsWindow();
            settings.Show();
        }

        private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Card card = deck.PickCard();
            CardViewControl.SetCardData(card.Value, card.Suit, card.Color);
        }
    }
}