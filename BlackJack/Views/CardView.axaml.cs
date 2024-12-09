using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BlackJack.Views
{
    public partial class CardView : UserControl
    {
        public CardView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            // Beispiel: Setze Kartendaten (dies w�re normalerweise durch DataBinding gesteuert)
            SetCardData("A", '\ue1ec', "Red");
        }

        public void SetCardData(string value, char unicodeSymbol, string color)
        {
            var topSymbol = this.FindControl<TextBlock>("TopSymbol");
            var centerSymbol = this.FindControl<TextBlock>("CenterSymbol");
            var bottomSymbol = this.FindControl<TextBlock>("BottomSymbol");

            string cardDisplay = $"{value}{unicodeSymbol}";

            topSymbol.Text = cardDisplay;
            centerSymbol.Text = unicodeSymbol.ToString();
            bottomSymbol.Text = cardDisplay;

            // Setze Farbe basierend auf der Eingabe
            if (color == "Red")
            {
                topSymbol.Foreground = Avalonia.Media.Brushes.Red;
                centerSymbol.Foreground = Avalonia.Media.Brushes.Red;
                bottomSymbol.Foreground = Avalonia.Media.Brushes.Red;
            }
            else
            {
                topSymbol.Foreground = Avalonia.Media.Brushes.Black;
                centerSymbol.Foreground = Avalonia.Media.Brushes.Black;
                bottomSymbol.Foreground = Avalonia.Media.Brushes.Black;
            }
        }
    }
}
