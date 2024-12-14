using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string text  = "hello";

        public MainViewModel()
        {
            Task.Run(async () =>
            {
                await Task.Delay(2000);
                Text = "juhuuu";
            });
        }
    }
}
