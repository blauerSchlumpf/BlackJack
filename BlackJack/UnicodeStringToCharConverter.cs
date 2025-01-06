//using Avalonia.Data.Converters;
//using System.Globalization;
//using System;

//namespace BlackJack
//{
//    public class UnicodeStringToCharConverter : IValueConverter
//    {
//        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            switch (value)
//            {
//                case '0': //Caro
//                    return (char)'\ue1ec';
//                case '1': //Herz
//                    return (char)'\ue2a8';
//                case '2': //Pik
//                    return (char)'\ue448';
//                case '3': //Kreuz
//                    return (char)'\ue1ba';
//                default:
//                    return (char)'\ue4e0';
//            }
//        }

//        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            switch (value)
//            {
//                case (char)'\ue448':
//                    return (int)0;
//                case (char)'\ue2a8':
//                    return (int)1;
//                case (char)'\ue1ec':
//                    return (int)2;
//                case (char)'\ue1ba':
//                    return (int)3;
//                default:
//                    return (int)404;
//            }
//        }
//    }
//}