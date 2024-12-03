using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        int deckCount = 6;
        Stack<Card> deck = new Stack<Card>();

        void NewDeck()
        {
            for (int i = 0; i < deckCount; i++) 
            {
                for (int s = 0; s < 4; s++)
                {
                    for (int v = 0; v < 13; v++)
                    {
                        deck.Push(new Card ( (Suit)s, (CardValue)v ));
                    }
                }
            }
        }
    }
}
