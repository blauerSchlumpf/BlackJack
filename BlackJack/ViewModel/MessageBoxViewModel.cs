using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;

public class MessageBoxViewModel
{
    public string Message { get; }

    public IRelayCommand CloseCommand { get; }

    private readonly Window window;

    public MessageBoxViewModel(string message, Window window)
    {
        Message = message;
        this.window = window;
        
        CloseCommand = new RelayCommand(() => window.Close());
    }
}
