using BlackJack.Model;
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
        bool gameOver = false;
        [ObservableProperty]
        int betSliderValue;
        [ObservableProperty]
        bool isBetValid;
        Result result;
        private string _betInputText = string.Empty;
        public string BetInputText
        {
            get => _betInputText;
            set
            {
                SetProperty(ref _betInputText, value);

                IsBetValid = int.TryParse(value, out var result);

                if (IsBetValid)
                {
                    BetSliderValue = result;
                }
            }
        }
        
        ChartData chartData;
        [ObservableProperty]
        Dealer dealer;
        [ObservableProperty]
        Player player;
        public GameMaster gameMaster { get; set; }

        public GameViewModel(ChartData chartData, Result result)
        {
            this.result = result;
            this.chartData = chartData;
            gameMaster = new GameMaster(chartData, 1000, result);
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
            gameMaster = new GameMaster(chartData, Player.Budget, result);
            BetSliderValue = 0;
            BetInputText = string.Empty;
            BudgetVisibility = true;
            ButtonEnabled = false;
            Dealer = gameMaster.dealer;
            Player = gameMaster.player;
            gameMaster.ClearCards();
            gameMaster.OnPlayerLost +=DealersTurnCommand;
            gameMaster.DealerDone += ShowResult;
        }

        partial void OnBetSliderValueChanged(int value)
        {
            BetInputText = BetSliderValue.ToString();
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
            gameMaster.StartGame();
        }

        [RelayCommand]
        public void AddBudget(string _budget)
        {
            int budget = Convert.ToInt32(Player.Budget * double.Parse(_budget));

            BetInputText = budget.ToString();
        }

        [RelayCommand]
        public void AllIn()
        {
            gameMaster.SetBet(Player.Budget);
            BudgetVisibility = false;
            ButtonEnabled = true;
            gameMaster.StartGame();
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