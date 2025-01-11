using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

public class ChartData : ObservableObject
{
    // Daten für die Chart-Serien
    public ObservableCollection<int> BudgetData { get; } = new ObservableCollection<int>();
    public ObservableCollection<int> BetData { get; } = new ObservableCollection<int>();
    public ObservableCollection<int> ProfitData { get; } = new ObservableCollection<int>();

    public void AddDataPoint(int budget, int bet, int profit)
    {
        BudgetData.Add(budget);
        BetData.Add(bet);
        ProfitData.Add(profit);

        // Benachrichtige ViewModel oder andere Klassen, falls nötig
        OnPropertyChanged(nameof(BudgetData));
        OnPropertyChanged(nameof(BetData));
        OnPropertyChanged(nameof(ProfitData));
    }
}
