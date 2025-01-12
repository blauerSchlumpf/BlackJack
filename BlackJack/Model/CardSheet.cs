using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Model
{
    class CardSheet
    {
        int sheetCount = 1;
        int shuffleCount = 5;
        List<Card> sheet = new List<Card>();

        public CardSheet()
        {
            for (int i = 0; i < sheetCount; i++)
            {
                for (int s = 0; s < 4; s++)
                {
                    for (int v = 1; v < 14; v++)
                    {
                        sheet.Add(new Card(s, v));
                    }
                }
            }
            Shuffle();
        }
        
        void Shuffle()
        {
            for (int i = 0; i < shuffleCount; i++)
            {
                var rnd = new Random();
                sheet = sheet.OrderBy(x => rnd.Next()).ToList();
            }

        }

        public Card PickCard()
        {
            Card card = sheet[0];
            sheet.RemoveAt(0);
            Console.WriteLine(card.Suit);
            return card;
        }
    }
}
