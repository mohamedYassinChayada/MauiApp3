using MauiApp3.Models;
using System.Globalization;

namespace MauiApp3.Converters
{
    public class MatchResultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MatchResult result = (MatchResult)value;
            string param = parameter.ToString();

            if (param == "TeamA")
            {
                if (result == MatchResult.TeamAWon)
                    return Colors.LightGreen;
                else
                    return Colors.LightGray;
            }

            if (param == "TeamB")
            {
                if (result == MatchResult.TeamBWon)
                    return Colors.LightGreen;
                else
                    return Colors.LightGray;
            }

            if (param == "ResultText")
            {
                if (result == MatchResult.TeamAWon)
                    return "Team A Won";
                if (result == MatchResult.TeamBWon)
                    return "Team B Won";
                return "NULL";
            }

            if (param == "ResultColor")
            {
                if (result == MatchResult.Pending)
                    return Colors.Red;
                else
                    return Colors.Black;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
