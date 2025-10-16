using MauiApp3.Models;
using System.Globalization;

namespace MauiApp3.Converters
{
    public class ResultToBorderColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is MatchResult result)
            {
                return result switch
                {
                    MatchResult.TeamAWon => Colors.Green,
                    MatchResult.TeamBWon => Colors.Red,
                    MatchResult.Pending => Colors.Gray,
                    _ => Colors.Transparent
                };
            }
            return Colors.Transparent;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
