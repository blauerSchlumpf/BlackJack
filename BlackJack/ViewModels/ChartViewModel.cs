using BlackJack.ViewModels;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp; // Für die Farbangaben
using System.Collections.ObjectModel;

namespace BlackJack.ViewModels;
public class ChartViewModel : ViewModelBase
{
    private readonly ChartData data;

    public ObservableCollection<ISeries> ChartData { get; }

    public ChartViewModel(ChartData dataProvider)
    {
        data = dataProvider;

        // Binde die Daten an die Chart-Serien und setze Farben
        ChartData = new ObservableCollection<ISeries>
        {
            new LineSeries<int>
            {
                Values = data.BudgetData,
                Name = "Budget",
                Stroke = new SolidColorPaint(SKColors.LightBlue), // Linienfarbe
                Fill = new SolidColorPaint(SKColors.LightBlue.WithAlpha(50)) // Füllfarbe (transparent)
            },
            new LineSeries<int>
            {
                Values = data.BetData,
                Name = "Einsatz",
                Stroke = new SolidColorPaint(SKColors.OrangeRed), // Linienfarbe
                Fill = new SolidColorPaint(SKColors.OrangeRed.WithAlpha(50)) // Füllfarbe (transparent)
            },
            new LineSeries<int>
            {
                Values = data.ProfitData,
                Name = "Gewinn",
                Stroke = new SolidColorPaint(SKColors.LimeGreen), // Linienfarbe
                Fill = new SolidColorPaint(SKColors.LimeGreen.WithAlpha(50)) // Füllfarbe (transparent)
            }
        };
    }
}
