using Avalonia.Controls;
using Avalonia.Controls.Templates;
using BlackJack.ViewModels;
using System;

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
            if (viewName != null)
            {
                var type = Type.GetType(viewName);
                if (type != null)
                {
                    return (Control)Activator.CreateInstance(type)!;
                }
            }
            return null;
        }

        public bool Match(object? data) => data is ViewModelBase;
    }
}