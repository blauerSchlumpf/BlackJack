using BlackJack.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

public class Player : ObservableObject
{

    public ObservableCollection<Card> Sheet { get; set; } = new ObservableCollection<Card>();
    int budget;
    public int Budget { 
        get => budget; 
        set =>SetProperty(ref budget, value); 
    }
     int bet;
    public int Bet {
        get => bet;
        set {
            if (value < 1)
            {
                SetProperty(ref bet, 1);
            }
            else if (value > Budget)
            {
                SetProperty(ref bet, Budget);
            }
            else
            {
                SetProperty(ref bet, value);
            }
        }
    }


     int points;
    public int Points
    {
        get => points;
        set => SetProperty(ref points, value); 
    }

    public Player()
    {
        Budget = 600;
        Sheet = new ObservableCollection<Card>();
    }

    public void Hit(Card card)
    {
        Sheet.Add(card);
        Points += card.Point;
    }
}
