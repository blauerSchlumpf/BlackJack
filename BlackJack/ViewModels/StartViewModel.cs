using Avalonia.Controls.Converters;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;
using System.Text.Json;
using BlackJack.Model;
using Newtonsoft.Json;
using Avalonia.Controls;

namespace BlackJack.ViewModels;
public partial class StartViewModel : ViewModelBase
{
    public event Action<string>? OnStartGame;
    [ObservableProperty]
    string username;

    [ObservableProperty]
    bool isUsernameValid;

    [ObservableProperty]
    string hUHU;

    JsonArray Results;

    [ObservableProperty]
    ObservableCollection<LeaderboardData> leaderboardDatas = new ObservableCollection<LeaderboardData>();

    public StartViewModel()
    {
        HUHU = "HUHU";
        Test();
    }

    async void GetResults()
    {
        //JsonArray Results = await ApiController.GetResults();
        //LeaderboardDatas = JsonConvert.DeserializeObject<ObservableCollection<LeaderboardData>>(Results.ToString());
        
    }

    public void Test()
    {
        LeaderboardDatas.Add(new LeaderboardData { username = "Test", budget = 1000, games_won = 0, games_lost = 0, success_rate = 0 });
        HUHU = LeaderboardDatas[0].username;
    }

    partial void OnUsernameChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            IsUsernameValid = false;
        }
        else
        {
            IsUsernameValid = true;
        }
    }

    [RelayCommand]
    void StartGame()
    {
        OnStartGame?.Invoke(Username);
    }
}

