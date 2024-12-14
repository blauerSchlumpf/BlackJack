using Avalonia.Controls;
using BlackJack.Model;
using BlackJack.Views;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using Views;

namespace BlackJack
{
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();
        Player player;
        int sheetCount = 0;
        ObservableCollection<Card> cards = new ObservableCollection<Card>();
        public MainWindow()
        {
            InitializeComponent();
            player =  new Player();
            DataContext = new { player };
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
            //PlayerSheet.Children.Add(cardView);
            player.Sheet.Add(card);
            cards.Add(card);
            sheetCount += card.Point;
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