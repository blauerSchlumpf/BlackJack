using BlackJack.Model;
using System.Collections.ObjectModel;

public interface IPlayerDealer
{
    ObservableCollection<Card> Sheet { get; set; }
    int Points { get; set; }

    void Hit(Card card);
}
