using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player : IPlayer
    {
        public int sheetCount;
        public ObservableCollection<Card> Sheet = new ObservableCollection<Card>();
        public int Budget { get; set; }

        public void SheetCount()
        {
            int index = -1;
            int sum = 0;
            foreach (Card card in Sheet)
            {
                if (card.Value == "A")
                {
                    index = Sheet.IndexOf(card);
                }
                sum += card.Point;
                
            }
            if (sum > 21 && index > -1)
            {
                Sheet[index].Point = 1;
            }
            sheetCount = sum;
        }

    }
}
