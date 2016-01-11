using System;
using System.Globalization;
using System.Windows.Data;

namespace GloomyMon.Converters
{
    public class DoubleToIntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var newValue = int.Parse(value.ToString())*100;
            return newValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
