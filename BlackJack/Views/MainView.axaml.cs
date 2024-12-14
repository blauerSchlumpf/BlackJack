using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BlackJack.ViewModel;

namespace BlackJack.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}