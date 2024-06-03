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
        public static Color AcceptableColor { get; set; } = Colors.GreenYellow;
        public static Color ErrorColor { get; set; } = Colors.Red;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double tempValue)
            {
                if (tempValue < 250 || tempValue > 350)
                    return new SolidColorBrush(ErrorColor);
                else
                    return new SolidColorBrush(AcceptableColor);
            }
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
