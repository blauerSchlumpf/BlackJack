using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Card
    {
        public string Suit { get; set; }
        List<string> suits = new List<string>() {"Pik", "Herz", "Karo", "Kreuz"};
        List<char> Values = new List<char>() {'A', 'B', 'D', 'K'};
        public char Value { get; set; }
        public int Point {get;}
        public Card(int suit, int value) 
        {
            if (value == 1)
            {
                Value = Values[0];
                Point = 11;
            }
            else if (value > 10)
            {
                Value = Values[value - 10];
                Point = 10;
            }
            else 
            {
                Value = (char)value;
                Point = value;

            }
            Suit = suits[suit];
        }
    }
}
