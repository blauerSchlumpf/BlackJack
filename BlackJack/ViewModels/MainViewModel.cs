using BlackJack.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BlackJack.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        ChartViewModel chartViewModel;
        GameViewModel gameViewModel;
        StartViewModel startViewModel;
        ChartData chartData;
        Result result;

        [ObservableProperty]
        bool gameOver;

        [ObservableProperty]
        bool statsOpened;

        [ObservableProperty]
        char statsCloseIcon;

        [ObservableProperty]
        ViewModelBase currentPage;

        [ObservableProperty]
        bool hasGameStarted;

        [ObservableProperty]
        string? username;

        public MainViewModel()
        {
            result = new Result();
            StatsCloseIcon = '\ue154';
            chartData = new ChartData();
            chartViewModel = new ChartViewModel(chartData);
            gameViewModel = new GameViewModel(chartData, result);
            startViewModel = new StartViewModel();
            startViewModel.OnStartGame += OnStartGameHandler;
            gameViewModel.OnGameOver += OnGameOverHandler;
            CurrentPage = startViewModel;
        }

        void OnStartGameHandler(string username)
        {
            Username = username;
            result.Username = Username;            
            CurrentPage = gameViewModel;
            HasGameStarted = true;
        }

        partial void OnStatsOpenedChanged(bool value)
        {
            StatsCloseIcon = value ? '\ue4f6' : '\ue154';
        }

        void OnGameOverHandler()
        {
            GameOver = true;
        }

        [RelayCommand]
        void ChangeView()
        {
            StatsOpened = !StatsOpened;
            if (StatsOpened)
            {
                CurrentPage = chartViewModel;
                chartViewModel.GetResults();
            }
            else
            {
                CurrentPage = gameViewModel;
            }
        }

        [RelayCommand]
        void RestartGame()
        {
            GameOver = false;
            StatsOpened = false;
            chartData = new ChartData();
            chartViewModel = new ChartViewModel(chartData);
            gameViewModel = new GameViewModel(chartData, result);
            CurrentPage = gameViewModel;
            startViewModel.OnStartGame += OnStartGameHandler;
            gameViewModel.OnGameOver += OnGameOverHandler;

        }
    }
}