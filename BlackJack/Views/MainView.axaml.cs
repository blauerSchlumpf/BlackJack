using Avalonia.Controls;
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