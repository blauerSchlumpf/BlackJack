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

            gameMaster.OnPlayerLost = () =>
            {
                DealersTurnCommand();
            };
        }

        [RelayCommand]
        public void NewCardCommand()
        {
            gameMaster.PlayerHit();
        }

        [RelayCommand]
        public async void DealersTurnCommand()
        {
            ButtonEnabled = false;
            gameMaster.DealerMakeMove();

            await ShowResultAsync();
        }

        [RelayCommand]
        public void SetBudgetCommand()
        {
            gameMaster.SetBet(BetSliderValue);
            BudgetVisibility = false;
            ButtonEnabled = true;
        }

        public async Task ShowResultAsync()
        {
            var result = gameMaster.Result;

            // Zeige das Ergebnis in einem Dialog an
            var window = new Views.MessageBoxWindow();
            window.DataContext = new MessageBoxViewModel(result, window);
            window.Show();
        }
    }

}
