using BlackJack.Model;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Newtonsoft.Json;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;

namespace BlackJack.ViewModels;
public class ChartViewModel : ViewModelBase
{
    private readonly ChartData data;
    public ObservableCollection<ISeries> ChartData { get; }
    public ObservableCollection<LeaderboardData> LeaderboardDatas { get; } = new ObservableCollection<LeaderboardData>();

    public ChartViewModel(ChartData dataProvider)
    {
        data = dataProvider;

        ChartData = new ObservableCollection<ISeries>
        {
            new LineSeries<int>
            {
                Values = data.BudgetData,
                Name = "Budget",
                Stroke = new SolidColorPaint(SKColors.LightBlue),
                Fill = new SolidColorPaint(SKColors.LightBlue.WithAlpha(50))
            },
            new LineSeries<int>
            {
                Values = data.BetData,
                Name = "Einsatz",
                Stroke = new SolidColorPaint(SKColors.OrangeRed),
                Fill = new SolidColorPaint(SKColors.OrangeRed.WithAlpha(50))
            },
            new LineSeries<int>
            {
                Values = data.ProfitData,
                Name = "Gewinn",
                Stroke = new SolidColorPaint(SKColors.LimeGreen),
                Fill = new SolidColorPaint(SKColors.LimeGreen.WithAlpha(50))
            }
        };
    }

    public async void GetResults()
    {
        LeaderboardDatas.Clear();
        JsonArray results = await ApiController.GetResults();

        if (results != null)
        {
            foreach (var item in results)
            {
                var jsonElement = item as JsonObject;
                if (jsonElement != null)
                {
                    var data = JsonConvert.DeserializeObject<LeaderboardData>(jsonElement.ToString());
                    if (data != null)
                    {
                        LeaderboardDatas.Add(data);
                    }
                }
            }
        }
    }
}
