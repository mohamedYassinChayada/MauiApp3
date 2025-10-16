using MauiApp3.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp3.ViewModel
{
    public class MatchViewModel : INotifyPropertyChanged
    {
        private Match _currentMatch;
        private int _currentIndex;
        private readonly ObservableCollection<Match> _matches;
        private System.Timers.Timer _timer;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Match CurrentMatch
        {
            get => _currentMatch;
            set
            {
                _currentMatch = value;
                OnPropertyChanged();
            }
        }

        public MatchViewModel()
        {
            // Initialize static list of 10 matches with different results
            _matches = new ObservableCollection<Match>
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

            // Setup timer to change match every 3 seconds
            _timer = new System.Timers.Timer(3000);
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void OnTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            _currentIndex = (_currentIndex + 1) % _matches.Count;
            
            // Update on UI thread
            MainThread.BeginInvokeOnMainThread(() =>
            {
                CurrentMatch = _matches[_currentIndex];
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ~MatchViewModel()
        {
            _timer?.Stop();
            _timer?.Dispose();
        }
    }
}
