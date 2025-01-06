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
        public Action OnPlayerLost;
        public string Result { get; set; } = string.Empty;

        public Player player;
        public Dealer dealer;
        public CardSheet cardSheet;

        bool canMakeMove;
        public bool CanMakeMove
        {
            get => canMakeMove;
            set => SetProperty(ref canMakeMove, value);
        }

        double winIndicator;
        public GameMaster() 
        {
            winIndicator = 5.0;
            cardSheet = new CardSheet();
            player = new Player();
            dealer = new Dealer();
            CanMakeMove = true;
          
        }

        public void StartGame()
        {
            player.Hit(cardSheet.PickCard());
            player.Hit(cardSheet.PickCard());
            dealer.Hit(cardSheet.PickCard());
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
            if (TooManyCards(player.Sheet, player.Points))
            {
                OnPlayerLost.Invoke();
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
            while (moveMade && !TooManyCards(dealer.Sheet, dealer.Points))
            {
                moveMade = dealer.Hit(cardSheet.PickCard());
            }
            FindWinner();
        }

        public void FindWinner()
        {
            GetPlayerWins();
            GetBlackJack();
        }

        public bool TooManyCards(ObservableCollection<Card> cards, int points)
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

        public void GetBlackJack()
        {
            if (player.Sheet.Count == 2 && player.Points == 21 || dealer.Sheet.Count == 2 && dealer.Points == 21)
            {
                Result = "Spieler gewinnt mit BlackJack";
                winIndicator = 2.5;
                if (dealer.Sheet.Count == 2 && dealer.Points == 21)
                {
                    Result = "Dealer gewinnt mit BlackJack";
                    winIndicator = 0;
                }
                if (player.Sheet.Count == 2 && player.Points == 21 && dealer.Sheet.Count == 2 && dealer.Points == 21)
                {
                    Result = "Unendschieden! Spieler und Dealer haben Blackjack.";
                    winIndicator = 1;
                }
            }
        }

        public void GetPlayerWins()
        {
            if (player.Points > 21 || dealer.Points > 21)
            {
                if (player.Points > 21)
                {
                    Result = "Dealer gewinnt! Spieler hat sich überkauft";
                    winIndicator = 0;
                }else if (dealer.Points > 21) 
                {                    
                    Result = "Spieler gewinnt! Dealer hat sich überkauft";
                    winIndicator = 2; 
                }
                else
                {
                    Result = "Unendschieden! Alle haben sich überkauft";
                    winIndicator = 1;
                }
            } else {
                if (player.Points > dealer.Points)
                {
                    Result = "Spieler gewinnt!";
                    winIndicator = 2;
                }
                else if (dealer.Points > player.Points)
                {
                    Result = "Dealer gewinnt!";
                    winIndicator = 0;
                }
                Result = "Unentschieden";
                winIndicator = 1;
            }
        }
    }
}
