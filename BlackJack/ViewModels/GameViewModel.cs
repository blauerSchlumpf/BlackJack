﻿using BlackJack.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace BlackJack.ViewModels
{
    partial class GameViewModel : ViewModelBase
    {
        public event Action? OnGameOver;
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
        Dealer? dealer;
        [ObservableProperty]
        Player? player;

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
            if(Player.Budget <= 0)
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
        public void NewCard()
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
        public void SetBudget()
        {
            gameMaster.SetBet(BetSliderValue);
            BudgetVisibility = false;
            ButtonEnabled = true;
        }

        [RelayCommand]
        public void AllIn()
        {
            gameMaster.SetBet(Player.Budget);
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
