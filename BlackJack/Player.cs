using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player : IPlayer
    {

        ObservableCollection<Card> sheet = new ObservableCollection<Card>();
        public int Budget { get; set; }

        int SheetCount()
        {
            int index = -1;
            int sum = 0;
            foreach (Card card in sheet)
            {
                if (card.Value == "A")
                {
                    index = sheet.IndexOf(card);
                }
                sum += card.Point;
                
            }
            if (sum > 21 && index > -1)
            {
                sheet[index].Point = 1;
            }
            return sum;
        }

    }
}
