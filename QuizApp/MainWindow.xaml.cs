using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace QuizApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Quiz> Quizzes { get; set; } = new ObservableCollection<Quiz>();
        private ObservableCollection<PlayerScore> PlayerScores { get; set; } = new ObservableCollection<PlayerScore>();


        public MainWindow()
        {
            InitializeComponent();

            QuizListBox.ItemsSource = Quizzes; // Привязываем список викторин
            BestScoresListBox.ItemsSource = PlayerScores;
        }

        // Создание новой викторины
        private void CreateQuiz_Click(object sender, RoutedEventArgs e)
        {
            var createQuizWindow = new CreateQuizWindow();

            // Подписываемся на событие для получения созданной викторины
            createQuizWindow.QuizCreated = quiz =>
            {
                Quizzes.Add(quiz); // Добавляем викторину в список
            };

            createQuizWindow.ShowDialog();
        }

        // Сохранение викторины в файл
        private void SaveQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (QuizListBox.SelectedItem is not Quiz selectedQuiz)
            {
                MessageBox.Show("Выберите викторину для сохранения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON файлы (*.json)|*.json",
                Title = "Сохранить викторину"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                selectedQuiz.SaveToFile(saveFileDialog.FileName);
                MessageBox.Show("Викторина успешно сохранена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Загрузка викторины из файла
        private void LoadQuiz_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON файлы (*.json)|*.json",
                Title = "Загрузить викторину"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var loadedQuiz = Quiz.LoadFromFile(openFileDialog.FileName);
                    Quizzes.Add(loadedQuiz);
                    QuizListBox.Items.Refresh();
                    MessageBox.Show("Викторина успешно загружена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка при загрузке файла. Убедитесь, что файл имеет правильный формат.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void StartQuizButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuizListBox.SelectedItem is Quiz selectedQuiz)
            {
                var quizPlayWindow = new QuizPlayWindow(selectedQuiz);
                quizPlayWindow.QuizCompleted += OnQuizCompleted;
                quizPlayWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите викторину для прохождения!");
            }
        }
        private void OnQuizCompleted(PlayerScore score)
        {
            // Добавляем нового игрока в список
            PlayerScores.Add(score);

            // Сортируем игроков по количеству правильных ответов (от большего к меньшему)
            var sortedScores = PlayerScores.OrderByDescending(s => s.CorrectAnswers).ToList();

            // Обновляем PlayerScores с отсортированными значениями
            PlayerScores.Clear();
            foreach (var sortedScore in sortedScores)
            {
                PlayerScores.Add(sortedScore);
            }
        }


        private void ShowLeaderboard_Click(object sender, RoutedEventArgs e)
        {
            var leaderboardWindow = new LeaderboardWindow(PlayerScores);
            leaderboardWindow.ShowDialog();
        }
        private void EditQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (QuizListBox.SelectedItem is Quiz selectedQuiz)
            {
                var editWindow = new EditQuizWindow(selectedQuiz);
                if (editWindow.ShowDialog() == true)
                {
                    // Обновляем список после редактирования
                    QuizListBox.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите викторину для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (Quizzes.Count == 0)
            {
                MessageBox.Show("Все викторины удалены. Список пуст.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (QuizListBox.SelectedItem is Quiz selectedQuiz)
            {
                // Подтверждение удаления
                var result = MessageBox.Show($"Вы уверены, что хотите удалить викторину \"{selectedQuiz.Title}\"?",
                    "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Quizzes.Remove(selectedQuiz); // Удаляем викторину из коллекции
                    QuizListBox.Items.Refresh();  // Обновляем ListBox
                    MessageBox.Show("Викторина успешно удалена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите викторину для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


    }
}
