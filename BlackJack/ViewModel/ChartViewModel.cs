using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
using System.Linq;

namespace BlackJack.ViewModel
{
    public class ChartViewModel
    {
        public ObservableCollection<ISeries> ChartData { get; set; }

        public ChartViewModel() 
        {
            ChartData = new ObservableCollection<ISeries>{
            new LineSeries<int>
                {
                    Values = new int[] {},
                    Name = "Budget"
                },
                new LineSeries<int>
                {
                    Values = new int[] {},
                    Name = "Einsatz"
                },
                new LineSeries<int>
                {
                    Values = new int[] {},
                    Name = "Gewinn"
                }
            };
        }

        public void UpdateChart(int budget, int bet, int profit)
        {
            var budgetSeries = (LineSeries<int>)ChartData.First(s => s.Name == "Budget");
            budgetSeries.Values = budgetSeries.Values.Append(budget).ToList();

            var betSeries = (LineSeries<int>)ChartData.First(s => s.Name == "Einsatz");
            betSeries.Values = betSeries.Values.Append(bet).ToList();

            var profitSeries = (LineSeries<int>)ChartData.First(s => s.Name == "Gewinn");
            profitSeries.Values = profitSeries.Values.Append(profit).ToList();
        }
    }
}   