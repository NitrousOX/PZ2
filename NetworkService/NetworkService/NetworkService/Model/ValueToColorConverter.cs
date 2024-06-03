using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace NetworkService.Model
{
    public class ValueToColorConverter : IValueConverter
    {
        public static Brush AcceptableColor { get; set; } = Brushes.GreenYellow;
        public static Brush ErrorColor { get; set; } = Brushes.Red;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double tempValue)
            {
                if (tempValue < 250 || tempValue > 350)
                    return ErrorColor;
                else
                    return AcceptableColor;
            }
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
