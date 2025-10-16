using MauiApp3.Models;
using System.Globalization;

namespace MauiApp3.Converters
{
    public class MatchResultConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not MatchResult result || parameter is not string param)
                return null;

            switch (param)
            {
                case "TeamA":
                    return result switch
                    {
                        MatchResult.TeamAWon => Colors.LightGreen,
                        _ => Colors.LightGray
                    };

                case "TeamB":
                    return result switch
                    {
                        MatchResult.TeamBWon => Colors.LightGreen,
                        _ => Colors.LightGray
                    };

                case "ResultText":
                    return result switch
                    {
                        MatchResult.TeamAWon => "Team A Won",
                        MatchResult.TeamBWon => "Team B Won",
                        MatchResult.Pending => "NULL",
                        _ => "Unknown"
                    };

                case "ResultColor":
                    return result == MatchResult.Pending ? Colors.Red : Colors.Black;

                default:
                    return null;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
