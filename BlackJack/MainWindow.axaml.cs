using Avalonia.Controls;
using BlackJack.Views;
using Microsoft.VisualBasic;
using Views;

namespace BlackJack
{
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();
        int points = 0;
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void OpenSettings(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var settings = new SettingsWindow();
            settings.Show();
        }

        private void HitClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Card card = deck.PickCard();
            var cardView = new CardView();
            cardView.SetCardData(card.Value, card.Suit, card.Color);

            PlayerSheet.Children.Add(cardView);
            points += card.Point;
            DataContext = this;
        }

        private void StandClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
        }
    }
}