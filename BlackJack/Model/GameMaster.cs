using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model
{
    class GameMaster : ObservableObject
    {
        public event Action<string> GameOver;
        string result;

        public Player player;
        public Dealer dealer;
        public CardSheet cardSheet;


        double winIndicator;
        public GameMaster() 
        {
            winIndicator = 5.0;
            cardSheet = new CardSheet();
            player = new Player();
            dealer = new Dealer();
          
        }

        public async void StartGame()
        {
            player.Hit(cardSheet.PickCard());
            player.Hit(cardSheet.PickCard());
            dealer.Hit(cardSheet.PickCard());
            if(GetBlackJack(player.Sheet, player.Points))
            {
                PayOut();
            }
            DealerMakeMove();

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
                result = "Dealer gewinnt, Spieler hat sich überkauft";
                winIndicator = 0;
            }
        }
        public void PayOut()
        {
            player.Budget += Convert.ToInt32(player.Bet * winIndicator);
            player.Bet = 0;
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
                if ()
                winIndicator = 2.5;
                return true;
            }
            return false;
        }

        public void GetPlayerWins(int playerPoints, int dealerPoints)
        {
            if (playerPoints > dealerPoints)
            {
                result = "Spieler gewinnt!";
                winIndicator = 2;
            }else if (dealerPoints > playerPoints) 
            {
                result = "Dealer gewinnt!";
                winIndicator =  0;    
            }
            result = "Unentschieden";
            winIndicator = 1;
        }
    }
}
