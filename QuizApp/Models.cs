using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

namespace QuizApp
{
    public class Question
    {
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> Options { get; set; }
    }
    public class Option
    {
        public string Name { get; set; }

        public Option(string name)
        {
            Name = name;
        }
    }

    public class Quiz
    {
        public string Title { get; set; }
        public List<Question> Questions { get; set; } = new();

        public void SaveToFile(string filePath)
        {
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static Quiz LoadFromFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Quiz>(json);
        }
    }
    public class PlayerScore
    {
        public string QuizTitle { get; set; }
        private string playerName;
        private int correctAnswers;
        private int totalQuestions;
        public string PlayerName
        {
            get => playerName;
            set
            {
                if (playerName != value)
                {
                    playerName = value;
                    OnPropertyChanged(nameof(PlayerName));
                }
            }
        }

        public int CorrectAnswers
        {
            get => correctAnswers;
            set
            {
                if (correctAnswers != value)
                {
                    correctAnswers = value;
                    OnPropertyChanged(nameof(CorrectAnswers));
                }
            }
        }

        public int TotalQuestions
        {
            get => totalQuestions;
            set
            {
                if (totalQuestions != value)
                {
                    totalQuestions = value;
                    OnPropertyChanged(nameof(TotalQuestions));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{PlayerName}: {CorrectAnswers}/{TotalQuestions} ({QuizTitle})";
        }
    }
}