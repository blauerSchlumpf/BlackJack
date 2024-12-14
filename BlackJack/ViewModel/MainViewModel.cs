using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlackJack.Model;
using ReactiveUI;
using CommunityToolkit.Mvvm.Input;

namespace BlackJack.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        ObservableCollection<Card> cards { get; set; } = new ObservableCollection<Card> { };

        public MainViewModel()
        {
        }

        [RelayCommand]
        public void NewCardCommand()
        {
            Console.WriteLine("neue kare");
            cards.Add(new Card(1, 1));
        }
    }

}
