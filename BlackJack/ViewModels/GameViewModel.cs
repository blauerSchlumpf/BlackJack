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
        public event Action OnGameOver;
        [ObservableProperty]
        bool budgetVisibility;
        [ObservableProperty]
        bool buttonEnabled;
        [ObservableProperty]
        bool gameOver;
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
            gameMaster.DealerDone += ShowResult;
        }

        public void RestartGame()
        {
            gameMaster.PayOut();
            if(player.Budget <= 0)
            {
                GameOver = true;
                OnGameOver?.Invoke();
            }
            gameMaster = new GameMaster(chartData, Player.Budget);
            BetSliderValue = 0;
            BudgetVisibility = true;
            ButtonEnabled = false;
            Dealer = gameMaster.dealer;
            Player = gameMaster.player;
            gameMaster.ClearCards();
            gameMaster.OnPlayerLost +=DealersTurnCommand;
            gameMaster.DealerDone += ShowResult;
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
        }


        [RelayCommand]
        public void SetBudgetCommand()
        {
            gameMaster.SetBet(BetSliderValue);
            BudgetVisibility = false;
            ButtonEnabled = true;
        }

        public void ShowResult()
        {
            var result = gameMaster.Result;
            var window = new Views.MessageBoxWindow();
            window.DataContext = new MessageBoxViewModel(result, window, RestartGame);
            window.Show();
        }
    }
}
