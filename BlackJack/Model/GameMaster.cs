using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model
{
    class GameMaster
    {
        public Player player;
        public Dealer dealer;
        public CardSheet cardSheet;
        public GameMaster() 
        { 
          player = new Player();
          dealer = new Dealer();
          cardSheet = new CardSheet();
            
        }

        public void StartGame()
        {
            //spieler muss einsatz setzen
            //karten werden verteilt
            //spieler darf ziehen solange er will/ u 22 ist
            //dealer zieht ggf
            // gewinn wird bekanntgegeben
            //geld wird ausgezahlt
        }
    }
}
