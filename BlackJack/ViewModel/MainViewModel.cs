﻿using System;
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

namespace BlackJack.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        bool budgetVisibility;
        [ObservableProperty]
        bool buttonEnabled;
        [ObservableProperty]
        int betSliderValue;
        GameMaster gameMaster { get; set; } = new GameMaster(600);
        Dealer Dealer => gameMaster.dealer;
        Player Player => gameMaster.player;


        public MainViewModel()
        {
            BudgetVisibility = true;

            gameMaster.OnPlayerLost = () =>
            {
                DealersTurnCommand();
            };
        }
        public void RestartGame()
        {
            gameMaster = new GameMaster(Player.Budget);
            ButtonEnabled = true;
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

            // Zeige das Ergebnis in einem Dialog an
            var window = new Views.MessageBoxWindow();
            window.DataContext = new MessageBoxViewModel(result, window, RestartGame);
            window.Show();
        }
    }

}
