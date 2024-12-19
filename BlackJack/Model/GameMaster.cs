using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            cardSheet = new CardSheet();
            player = new Player();
            dealer = new Dealer(cardSheet);
          
        }

        public async void StartGame()
        {
            player.Hit(cardSheet.PickCard());
            player.Hit(cardSheet.PickCard());
            dealer.Hit(cardSheet.PickCard());
            if(GetBlackJack(player.Sheet, player.Points))
            {
                //spieler hat blackjack und gewonnen
            }
            
        }

        public void SetBet(int bet)
        {
            player.Bet = bet;
            player.Budget -= player.Bet;
            StartGame();
        }

        public void PlayerHit()
        {
            player.Hit(cardSheet.PickCard());
            if (GetLoser(player.Sheet, player.Points))
            {
                // spieler verliert
            }
        }
        
        public void DealerMakeMove()
        {
            bool moveMade = true;
            while (moveMade)
            {
                moveMade = dealer.Hit(cardSheet.PickCard());
            }

        }

        public bool GetLoser(ObservableCollection<Card> cards, int points)
        {
            if (points > 21)
            {
                foreach (Card card in cards)
                {
                    if (card.Point == 11){
                        points -= 10;
                        card.Point = 1;
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public bool GetBlackJack(ObservableCollection<Card> cards, int points)
        {
            if (cards.Count == 2 && points == 21)
            {
                return true;
            }
            return false;
        }

        public int GetPlayerWins(int playerPoints, int dealerPoints)
        {
            if (playerPoints > dealerPoints)
            {
                return 1;
            }else if (dealerPoints > playerPoints) 
            {
                return -1;    
            }
            return 0;
        }
    }
}
