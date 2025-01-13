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
using System.Diagnostics;

namespace BlackJack.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        ChartViewModel chartViewModel;
        GameViewModel gameViewModel;
        ChartData chartData;

        [ObservableProperty]
        bool gameOver;

        [ObservableProperty]
        bool statsOpened;

        [ObservableProperty]
        char statsCloseIcon;

        [ObservableProperty]
        ViewModelBase currentPage;

        public MainViewModel()
        {
            StatsCloseIcon = '\ue154';
            chartData = new ChartData();
            chartViewModel = new ChartViewModel(chartData);
            gameViewModel = new GameViewModel(chartData);
            CurrentPage = gameViewModel;
            gameViewModel.OnGameOver += OnGameOverHandler;

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
            gameViewModel = new GameViewModel(chartData);
            CurrentPage = gameViewModel;
        }
    }
}