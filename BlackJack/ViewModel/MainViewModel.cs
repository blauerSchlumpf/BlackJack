using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using BlackJack.Model;
using CommunityToolkit.Mvvm.Input;

namespace BlackJack.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        ObservableCollection<Card> PlayerCards { get; set; } = new ObservableCollection<Card> { };
        ObservableCollection<Card> DealerCards { get; set; }
        [ObservableProperty]
        bool budgetVisibility;
        [ObservableProperty]
        int betSliderValue;
        GameMaster gameMaster { get; set; } = new GameMaster();
        Dealer Dealer => gameMaster.dealer;
        Player Player => gameMaster.player;


        public MainViewModel()
        {
            BudgetVisibility = true;
        }

        [RelayCommand]
        public void NewCardCommand()
        {
            //Card card = gameMaster.cardSheet.PickCard();
            //PlayerCards.Add(card);
            //SumPlayer += card.Point;
            Player.Hit(gameMaster.cardSheet);
        }

        [RelayCommand]
        public void DealersTurnCommand()
        {
            Dealer.MakeMove(gameMaster.cardSheet);
        }

        [RelayCommand]
        public void SetBudgetCommand()
        {
            Player.Bet = BetSliderValue;
            budgetVisibility = false;
        }
    }

}
