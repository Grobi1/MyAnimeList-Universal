using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MyAnimeList.Converter
{
    class DecimalPlacesConverter : IValueConverter
    {
        public int Decimals { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                double val = (double)value;
                return Math.Round(val, Decimals);
            }
            catch { return 0; }

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
