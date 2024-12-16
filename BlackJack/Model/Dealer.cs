using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model
{
    class Dealer : ObservableObject
    {
        public ObservableCollection<Card> sheet { get; set; } = new ObservableCollection<Card>();
        CardSheet sheetSheet { get; set; }
        private int points;
        public int Points
        {
            get => points;
            set => SetProperty(ref points, value); // CommunityToolkit hilft dabei
        }
        public Dealer() { }

        public void MakeMove(CardSheet cardSheet) {
            sheetSheet = cardSheet;
            if(Points < 17)
            {
                Hit();
            }
        }

        void Hit()
        {
            Card card = sheetSheet.PickCard();
            sheet.Add(card);
            Points += card.Point;
        }

        void Stand() 
        {
            
        }
    }

}
