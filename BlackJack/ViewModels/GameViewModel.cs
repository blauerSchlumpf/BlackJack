using BlackJack.Model;
using CommunityToolkit.Mvvm.ComponentModel;
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
using Avalonia.Controls.ApplicationLifetimes;

namespace BlackJack.ViewModels
{
    partial class GameViewModel : ViewModelBase
    {
        [ObservableProperty]
        bool budgetVisibility;
        [ObservableProperty]
        bool buttonEnabled;
        [ObservableProperty]
        int betSliderValue;
        GameMaster gameMaster { get; set; } = new GameMaster(600);
        [ObservableProperty]
        Dealer dealer;
        [ObservableProperty]
        Player player;

        public GameViewModel()
        {
            Player = gameMaster.player;
            Dealer = gameMaster.dealer;
            BudgetVisibility = true;
            gameMaster.OnPlayerLost += DealersTurnCommand;
        }

        public void RestartGame()
        {
            gameMaster.PayOut();
            gameMaster = new GameMaster(Player.Budget);
            BetSliderValue = 0;
            BudgetVisibility = true;
            ButtonEnabled = false;
            Dealer = gameMaster.dealer;
            Player = gameMaster.player;
            gameMaster.ClearCards();
            gameMaster.OnPlayerLost +=DealersTurnCommand;
        }

        [RelayCommand]
        public void NewCardCommand()
        {
            gameMaster.PlayerHit();
        }

        [RelayCommand]
        public void DealersTurnCommand()
        {
            ButtonEnabled = false;
            gameMaster.DealerMakeMove();
            ShowResultAsync();
        }

        [RelayCommand]
        public void SetBudgetCommand()
        {
            gameMaster.SetBet(BetSliderValue);
            BudgetVisibility = false;
            ButtonEnabled = true;
        }

        public void ShowResultAsync()
        {
            var result = gameMaster.Result;
            var window = new Views.MessageBoxWindow();
            window.DataContext = new MessageBoxViewModel(result, window, RestartGame);
            window.Show();
        }
    }
}
