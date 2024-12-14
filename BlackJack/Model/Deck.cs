using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model
{
    class Deck
    {
        int deckCount = 1;
        int shuffleCount = 5;
        List<Card> deck = new List<Card>();

        public Deck()
        {
            for (int i = 0; i < deckCount; i++)
            {
                for (int s = 0; s < 4; s++)
                {
                    for (int v = 1; v < 14; v++)
                    {
                        deck.Add(new Card(s, v));
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
                deck = deck.OrderBy(x => rnd.Next()).ToList();
            }

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
