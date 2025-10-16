namespace MauiApp3.Models
{
    public enum MatchResult
    {
        Pending,
        TeamAWon,
        TeamBWon
    }

    public class Match
    {
        public string TeamA { get; set; } = string.Empty;
        public string TeamB { get; set; } = string.Empty;
        public MatchResult Result { get; set; }
        public string MatchNumber { get; set; } = string.Empty;
    }
}
