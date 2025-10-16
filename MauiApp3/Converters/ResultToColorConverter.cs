using MauiApp3.Models;
using System.Globalization;

namespace MauiApp3.Converters
{
    public class ResultToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is MatchResult result)
            {
                return result switch
                {
                    MatchResult.TeamAWon => Colors.LightGreen,
                    MatchResult.TeamBWon => Colors.LightCoral,
                    MatchResult.Pending => Colors.LightGray,
                    _ => Colors.White
                };
            }
            return Colors.White;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
