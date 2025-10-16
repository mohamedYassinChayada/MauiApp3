using MauiApp3.Models;
using System.Globalization;

namespace MauiApp3.Converters
{
    public class ResultToTextConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is MatchResult result)
            {
                return result switch
                {
                    MatchResult.TeamAWon => "Team A Won",
                    MatchResult.TeamBWon => "Team B Won",
                    MatchResult.Pending => "NULL",
                    _ => "Unknown"
                };
            }
            return "Unknown";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
