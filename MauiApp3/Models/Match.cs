namespace MauiApp3.Models
{
    public enum MatchResult
    {
        Null,
        TeamAWon,
        TeamBWon
    }

    public class Match
    {
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public MatchResult Result { get; set; }
        public string MatchNumber { get; set; }
    }
}
