using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Suit
    {
        public enum Test
        {
            Heart,
            Club,
            Diamond,
            Spade
        }

        public void TuEtwas()
        {
            Test d = Test.Diamond;
            Console.WriteLine($"Integral value of {d} is {(int)d}");  // output: Integral value of Autumn is 2

            var b = (Test)1;
            Console.WriteLine(b);  // output: Summer

            var c = (Test)4;
            Console.WriteLine(c);  // output: 4
        }
    }
}
