using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Converters
{
    public class ImageStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var target = (FlyoutItem)value;
            var allParams = ((string)parameter).Split(';');

            if (target.IsChecked && allParams.Length > 1)
            {
                return allParams[1];
            }
            else
            {
                return allParams[0];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value;
        }
    }
}
