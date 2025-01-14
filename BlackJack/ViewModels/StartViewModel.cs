using Avalonia.Controls.Converters;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public event Action? OnTest;


    [ObservableProperty]
    string username;

    [ObservableProperty]
    bool isUsernameValid;

    public ObservableCollection<LeaderboardData> LeaderboardDatas { get; } = new ObservableCollection<LeaderboardData>();
    public StartViewModel()
    {
        GetResults();
    }

    async void GetResults()
    {
        JsonArray results = await ApiController.GetResults();

        if(results != null)
        {
            foreach (var item in results)
            {
                var jsonElement = item as JsonObject;
                if(jsonElement != null)
                {
                    var data = JsonConvert.DeserializeObject<LeaderboardData>(jsonElement.ToString());
                    if (data != null)
                    {
                        LeaderboardDatas.Add(data);
                    }
                }
            }
        }
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
    public void StartGame()
    {
        OnTest?.Invoke();
        OnStartGame?.Invoke(Username);
    }
}

