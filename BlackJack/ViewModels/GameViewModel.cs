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
using Avalonia.Media.TextFormatting.Unicode;

namespace BlackJack.ViewModels
{
    partial class GameViewModel : ViewModelBase
    {
        event Action OnGameOver;
        [ObservableProperty]
        bool budgetVisibility;
        [ObservableProperty]
        bool buttonEnabled;
        [ObservableProperty]
        int betSliderValue;
        public GameMaster gameMaster { get; set; }
        ChartData chartData;
        [ObservableProperty]
        Dealer dealer;
        [ObservableProperty]
        Player player;

        public GameViewModel(ChartData chartData)
        {
            this.chartData = chartData;
            gameMaster = new GameMaster(chartData, 600);
            Player = gameMaster.player;
            Dealer = gameMaster.dealer;
            BudgetVisibility = true;
            gameMaster.OnPlayerLost += DealersTurnCommand;
        }

        public void RestartGame()
        {
            gameMaster.PayOut();
            if(player.Budget <= 0)
            {
                OnGameOver?.Invoke();
                return;
            }
            gameMaster = new GameMaster(chartData, Player.Budget);
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
