using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlackJack.Model;
using CommunityToolkit.Mvvm.Input;

namespace BlackJack.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        ObservableCollection<Card> PlayerCards { get; set; } = new ObservableCollection<Card> { };
        ObservableCollection<Card> DealerCards { get; set; }
        [ObservableProperty]
        int sumPlayer;
        [ObservableProperty]
        int sumDealer;
        GameMaster gameMaster { get; set; } = new GameMaster();
        Dealer Dealer => gameMaster.dealer;


        public MainViewModel()
        {
            DealerCards = gameMaster.dealer.sheet;
            SumDealer = gameMaster.dealer.Points;
        }

        [RelayCommand]
        public void NewCardCommand()
        {
            Card card = gameMaster.cardSheet.PickCard();
            PlayerCards.Add(card);
            SumPlayer += card.Point;
        }

        [RelayCommand]
        public void DealersTurnCommand()
        {
            Dealer.MakeMove(gameMaster.cardSheet);
        }
    }

}
