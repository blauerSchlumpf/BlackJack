using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Views;

public partial class SettingsWindow : Window
{
    public SettingsWindow()
    {
        InitializeComponent();
    }

    private void CloseApp(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.CloseApp(sender, e);
    }
}