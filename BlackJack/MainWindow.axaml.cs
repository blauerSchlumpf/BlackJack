using Avalonia.Controls;
using BlackJack.Views;
using Microsoft.VisualBasic;

namespace BlackJack
{
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void OpenSettings(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var settings = new SettingsWindow();
            settings.Show();
        }

        private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Card card = deck.PickCard();
            var cardView = new CardView();
            cardView.SetCardData(card.Value, card.Suit, card.Color);

            CardContainer.Children.Add(cardView);
        }
    }
}