using BlackJack.ViewModels;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
namespace BlackJack.ViewModels;
public class ChartViewModel : ViewModelBase
{
    private readonly ChartData data;

    public ObservableCollection<ISeries> ChartData { get; }

    public ChartViewModel(ChartData dataProvider)
    {
        data = dataProvider;

        // Binde die Daten an die Chart-Serien
        ChartData = new ObservableCollection<ISeries>
        {
            new LineSeries<int>
            {
                Values = data.BudgetData,
                Name = "Budget"
            },
            new LineSeries<int>
            {
                Values = data.BetData,
                Name = "Einsatz"
            },
            new LineSeries<int>
            {
                Values = data.ProfitData,
                Name = "Gewinn"
            }
        };
    }
}
