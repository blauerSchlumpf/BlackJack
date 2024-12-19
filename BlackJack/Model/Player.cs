using Avalonia;
using BlackJack.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

class Player : ObservableObject
{

    public ObservableCollection<Card> Sheet { get; set; } = new ObservableCollection<Card>();
    public int Budget { get; set; }
    private int points;
    public int Bet { get; set; }
    public int Points
    {
        get => points;
        set => SetProperty(ref points, value); // CommunityToolkit hilft dabei
    }

    public Player()
    {
        Budget = 600;
        Sheet = new ObservableCollection<Card>();
    }

    public void Hit(CardSheet sheet)
    {
        Card card = sheet.PickCard();
        Sheet.Add(card);
        Points += card.Point;
    }
}
