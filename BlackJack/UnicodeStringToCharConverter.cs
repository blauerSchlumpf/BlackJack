using Avalonia.Data.Converters;
using System.Globalization;
using System;

public class UnicodeStringToCharConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string unicodeString)
        {
            return (char)int.Parse(unicodeString.TrimStart('&').TrimStart('#').TrimEnd(';'), NumberStyles.HexNumber);
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}