using Avalonia.Controls;
using BlackJack.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace BlackJack.ViewModels;
public partial class MessageBoxViewModel
{
    public string Message { get; }

    //public IRelayCommand CloseCommand { get; }

    private readonly Window window;
    private readonly Action Restart;

    public MessageBoxViewModel(string message, Window window, Action Restart)
    {
        Message = message;
        this.Restart = Restart;
        this.window = window;

        //CloseCommand = new RelayCommand(() => window.Close());
    }

    [RelayCommand]
    public void CloseCommand()
    {
        Restart.Invoke();
        window.Close();
    }
}
