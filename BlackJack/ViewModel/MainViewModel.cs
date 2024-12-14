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
        ObservableCollection<Card> cards { get; set; } = new ObservableCollection<Card> { };
        GameMaster gameMaster { get; set; } = new GameMaster();

        public MainViewModel()
        {
        }

        [RelayCommand]
        public void NewCardCommand()
        {
            gameMaster.player.Sheet.Add(gameMaster.cardSheet.PickCard());
        }
    }

}
