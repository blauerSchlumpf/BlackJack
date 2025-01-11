using Avalonia.Controls;
using Avalonia.Controls.Templates;
using BlackJack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Views;

namespace BlackJack
{
    class ViewLocator : IDataTemplate
    {
        public Control? Build(object? data)
        {
            if (data is null)
            {
                return null;
            }

            var viewName = data.GetType().FullName?.Replace("ViewModel", "View");
            var type = Type.GetType(viewName);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }
            else
            {
                return null;
            }
        }

        public bool Match(object? data) => data is ViewModelBase;
    }
}
