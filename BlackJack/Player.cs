using BlackJack;
using System.Collections.ObjectModel;
using System.ComponentModel;

class Player : IPlayer, INotifyPropertyChanged
{
    private int _sheetCount;
    public int sheetCount
    {
        get => _sheetCount;
        set
        {
            _sheetCount = value;
            OnPropertyChanged(nameof(sheetCount));
        }
    }

    public ObservableCollection<Card> Sheet { get; set; }
    public int Budget { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public Player()
    {
        Budget = 600;
        Sheet = new ObservableCollection<Card>();
    }

    public void SheetCount()
    {
        int index = -1;
        int sum = 0;
        foreach (Card card in Sheet)
        {
            if (card.Value == "A")
            {
                index = Sheet.IndexOf(card);
            }
            sum += card.Point;
        }
        if (sum > 21 && index > -1)
        {
            Sheet[index].Point = 1;
        }
        sheetCount = sum; // Triggert PropertyChanged
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
