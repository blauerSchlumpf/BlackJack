using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BlackJack.ViewModels;

namespace BlackJack.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}