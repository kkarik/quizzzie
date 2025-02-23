using System.Collections.ObjectModel;
using System.Windows;

namespace QuizApp
{
    public partial class LeaderboardWindow : Window
    {
        public LeaderboardWindow(ObservableCollection<PlayerScore> scores)
        {
            InitializeComponent();
            LeaderboardListBox.ItemsSource = scores;
        }
    }
}