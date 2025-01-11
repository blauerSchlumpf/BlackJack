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

namespace BlackJack.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        readonly ChartViewModel chartViewModel = new ChartViewModel();
        readonly GameViewModel gameViewModel = new GameViewModel();

        bool StatsOpened { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(StatsOpened))]
        char test;

        [ObservableProperty]
        ViewModelBase currentPage;

        public MainViewModel()
        {
            CurrentPage = gameViewModel;
            Test = (StatsOpened ? '\ue4f6' : '\ue154');
        }

        //[RelayCommand]
        //public void ChangeView()
        //{
        //    StatsOpened = !StatsOpened;
        //    if (StatsOpened)
        //    {
        //        CurrentPage = chartViewModel;
        //    }
        //    else
        //    {
        //        CurrentPage = gameViewModel;
        //    }
        //}
    }
}