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

        [ObservableProperty]
        bool statsOpened;

        [ObservableProperty]
        bool gameOver;

        ChartData chartData;

        [ObservableProperty]
        char statsCloseIcon;

        [ObservableProperty]
        ViewModelBase currentPage;

        public MainViewModel()
        {
            StatsCloseIcon = (StatsOpened ? '\ue4f6' : '\ue154');
            chartData = new ChartData();
            chartViewModel = new ChartViewModel(chartData);
            gameViewModel = new GameViewModel(chartData);
            CurrentPage = gameViewModel;
            gameViewModel.OnGameOver += OnGameOverHandler;

        }

        void OnGameOverHandler()
        {
            gameOver = true;
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
            StatsCloseIcon = (StatsOpened ? '\ue4f6' : '\ue154');
        }

        [RelayCommand]
        void RestartGame()
        {
            chartData = new ChartData();
            chartViewModel = new ChartViewModel(chartData);
            gameViewModel = new GameViewModel(chartData);
            CurrentPage = gameViewModel;
        }
    }
}