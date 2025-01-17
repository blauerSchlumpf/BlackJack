using BlackJack.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;

namespace BlackJack.ViewModels;
public partial class StartViewModel : ViewModelBase
{
    public event Action<string>? OnStartGame;

    [ObservableProperty]
    string username = string.Empty;

    [ObservableProperty]
    bool isUsernameValid;

    public ObservableCollection<LeaderboardData> LeaderboardDatas { get; } = new ObservableCollection<LeaderboardData>();
    public StartViewModel()
    {
        GetResults();
    }

    async void GetResults()
    {
        JsonArray? results = await ApiController.GetResults();

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
        OnStartGame?.Invoke(Username);
    }
}