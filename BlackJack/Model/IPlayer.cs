using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model
{
    interface IPlayer
    {
        void Hit() { }

        void Stand() { }

        int SheetCount() { return 0; }
    }
}
