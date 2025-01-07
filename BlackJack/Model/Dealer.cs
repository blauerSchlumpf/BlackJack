using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model
{
    public class Dealer : ObservableObject
    {
        public ObservableCollection<Card> Sheet { get; set; } = new ObservableCollection<Card>();

        private int points;
        public int Points
        {
            get => points;
            set => SetProperty(ref points, value); // CommunityToolkit hilft dabei
        }
        public Dealer()
        {
        }

        public bool Hit(Card card)
        {
            if (Points < 17)
            {
                Sheet.Add(card);
                Points += card.Point;
                return true;
            }
            return false;
        }

    }

}
