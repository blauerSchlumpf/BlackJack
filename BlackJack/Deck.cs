using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        int deckCount = 1;
        List<Card> deck = new List<Card>();

        public Deck()
        {
            for (int i = 0; i < deckCount; i++)
            {
                for (int s = 0; s < 4; s++)
                {
                    for (int v = 0; v < 13; v++)
                    {
                       // deck.Add(new Card((Suit)s, (CardValue)v));
                    }
                }
            }
            Mischen();
        }

        void Mischen()
        {
            List<Card> stack = new List<Card>();
            var rnd = new Random();
           deck.OrderBy(x => rnd.Next()).ToList();
        }

        public Card PickCard()
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            Console.WriteLine(card.Suit);
            return card;
        }
    }
}
