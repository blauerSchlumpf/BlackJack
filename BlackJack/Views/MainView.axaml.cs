using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BlackJack.ViewModel;

namespace BlackJack.Views;

public partial class MainView : UserControl
{
    public MainViewModel ViewModel { get; set; }
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}