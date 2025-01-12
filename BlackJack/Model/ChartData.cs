using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

public class ChartData : ObservableObject
{
    public ObservableCollection<int> BudgetData { get; } = new ObservableCollection<int>();
    public ObservableCollection<int> BetData { get; } = new ObservableCollection<int>();
    public ObservableCollection<int> ProfitData { get; } = new ObservableCollection<int>();

    public void AddDataPoint(int budget, int bet, int profit)
    {
        BudgetData.Add(budget);
        BetData.Add(bet);
        ProfitData.Add(profit);

        OnPropertyChanged(nameof(BudgetData));
        OnPropertyChanged(nameof(BetData));
        OnPropertyChanged(nameof(ProfitData));
    }
}
