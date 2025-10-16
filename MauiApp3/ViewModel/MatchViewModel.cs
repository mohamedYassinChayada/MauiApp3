using MauiApp3.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace MauiApp3.ViewModel
{
    public class MatchViewModel : INotifyPropertyChanged
    {
        private Match _currentMatch;
        private int _currentIndex;
        private List<Match> _matches;
        private System.Timers.Timer _timer;

        public event PropertyChangedEventHandler PropertyChanged;

        public Match CurrentMatch
        {
            get { return _currentMatch; }
            set
            {
                _currentMatch = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentMatch)));
            }
        }

        public MatchViewModel()
        {
            _matches = new List<Match>
            {
                new Match { MatchNumber = "Match 1", TeamA = "Team A", TeamB = "Team B", Result = MatchResult.TeamAWon },
                new Match { MatchNumber = "Match 2", TeamA = "Team A", TeamB = "Team B", Result = MatchResult.TeamBWon },
                new Match { MatchNumber = "Match 3", TeamA = "Team A", TeamB = "Team B", Result = MatchResult.Pending },
                new Match { MatchNumber = "Match 4", TeamA = "Team A", TeamB = "Team B", Result = MatchResult.TeamAWon },
                new Match { MatchNumber = "Match 5", TeamA = "Team A", TeamB = "Team B", Result = MatchResult.Pending },
                new Match { MatchNumber = "Match 6", TeamA = "Team A", TeamB = "Team B", Result = MatchResult.TeamBWon },
                new Match { MatchNumber = "Match 7", TeamA = "Team A", TeamB = "Team B", Result = MatchResult.TeamAWon },
                new Match { MatchNumber = "Match 8", TeamA = "Team A", TeamB = "Team B", Result = MatchResult.TeamBWon },
                new Match { MatchNumber = "Match 9", TeamA = "Team A", TeamB = "Team B", Result = MatchResult.Pending },
                new Match { MatchNumber = "Match 10", TeamA = "Team A", TeamB = "Team B", Result = MatchResult.TeamAWon }
            };

            _currentIndex = 0;
            _currentMatch = _matches[_currentIndex];

            _timer = new System.Timers.Timer(3000);
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _currentIndex = _currentIndex + 1;
            if (_currentIndex >= _matches.Count)
                _currentIndex = 0;
            
            MainThread.BeginInvokeOnMainThread(() =>
            {
                CurrentMatch = _matches[_currentIndex];
            });
        }
    }
}
