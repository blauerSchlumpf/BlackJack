using Avalonia.Controls;

namespace BlackJack
{
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();
        public MainWindow()
        {
            InitializeComponent();

            var card = deck.PickCard();
            Suit suit = new Suit();
            suit.TuEtwas();
        }
    }
}