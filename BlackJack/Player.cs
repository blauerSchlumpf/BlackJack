using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player : IPlayer
    {

        List<int> sheet = new List<int>();
        public int Budget { get; set; }

        int SheetCount()
        {
            int sum = 0;
            foreach (int point in sheet)
            {
                sum += point;
                if (sum > 21)
                {
                    var a = sheet.Find(11);
                }
            }
            return sum;
        }

    }
}
