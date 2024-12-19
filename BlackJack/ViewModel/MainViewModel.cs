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
        bool buttonEnabled;
        [ObservableProperty]
        int betSliderValue;
        GameMaster gameMaster { get; set; } = new GameMaster();
        Dealer Dealer => gameMaster.dealer;
        Player Player => gameMaster.player;


        public MainViewModel()
        {
            BudgetVisibility = true;
            HitEnabled = true;
        }

        [RelayCommand]
        public void NewCardCommand()
        {
            gameMaster.PlayerHit();
        }

        [RelayCommand]
        public void DealersTurnCommand()
        {
            HitEnabled = false;
            gameMaster.DealerMakeMove();
        }

        [RelayCommand]
        public void SetBudgetCommand()
        {
            gameMaster.SetBet(BetSliderValue);
            BudgetVisibility = false;
        }
    }

}
