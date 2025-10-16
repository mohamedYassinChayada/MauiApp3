using MauiApp3.Models;
using System.Globalization;

namespace MauiApp3.Converters
{
    public class ResultLabelColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is MatchResult result)
            {
                return result switch
                {
                    MatchResult.Pending => Colors.Red,
                    _ => Colors.Black
                };
            }
            return Colors.Black;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
