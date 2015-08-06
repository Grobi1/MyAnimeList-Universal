using System;
using System.Windows;
using System.Globalization;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;

namespace MyAnimeList.Converter
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        private bool _inverted = false;
        public bool Inverted
        {
            get { return _inverted; }
            set { _inverted = value; }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool b = (bool)value;
            if (_inverted) b = !b;

            if (b)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
