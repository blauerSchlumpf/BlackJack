using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using System;

namespace BlackJack.ViewModels;
public partial class MessageBoxViewModel
{
    public string Message { get; }


    readonly Window window;
    readonly Action Restart;

    public MessageBoxViewModel(string message, Window window, Action Restart)
    {
        Message = message;
        this.Restart = Restart;
        this.window = window;
    }

    [RelayCommand]
    public void CloseCommand()
    {
        Restart.Invoke();
        window.Close();
    }
}
