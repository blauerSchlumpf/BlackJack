using Avalonia.Controls;
using BlackJack.Views;
using Microsoft.VisualBasic;
using Views;

namespace BlackJack
{
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();
        Player player = new Player();
        int sheetCount = 0;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
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

            // Anstelle playersheet observablecollection des Players
            PlayerSheet.Children.Add(cardView);
            player.Sheet.Add(card);
            sheetCount += card.Point;
            DataContext = this;
            //var test = TopSymbol.text;

            // Hier die summe der Karten ausrechnen
            //var gesmtwert = 0;
            //foreach (var object in PlayerSheet.Children)
            //{
            //    var card = object as CardView;
            //    gesmtwert += card.Wert;
            //}
            //card_count_label.Content = 5;

        }

        private void StandClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
        }
    }
}