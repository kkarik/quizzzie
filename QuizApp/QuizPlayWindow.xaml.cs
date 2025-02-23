using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace QuizApp
{
    public partial class QuizPlayWindow : Window
    {
        private Quiz CurrentQuiz;
        private int CurrentQuestionIndex = 0;
        private int CorrectAnswers = 0;

        private string SelectedAnswer = null; // Храним текущий выбранный ответ
        private string PlayerName; // Имя игрока

        private DispatcherTimer Timer; // Таймер
        private int TimeLeft = 15; // Время на вопрос (в секундах)

        public delegate void QuizCompletedHandler(PlayerScore score);
        public event QuizCompletedHandler QuizCompleted;

        public QuizPlayWindow(Quiz quiz)
        {
            InitializeComponent();
            CurrentQuiz = quiz;

            // Запрашиваем имя игрока
            PlayerName = RequestPlayerName();

            // Если игрок не ввел имя, закрываем окно
            if (string.IsNullOrWhiteSpace(PlayerName))
            {
                MessageBox.Show("Имя игрока не введено. Викторина не может быть начата.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }

            // Инициализация таймера
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += TimerTick;

            LoadQuestion();
        }

        private string RequestPlayerName()
        {
            var enterNameWindow = new EnterNameWindow();
            if (enterNameWindow.ShowDialog() == true)
            {
                return enterNameWindow.PlayerName;
            }
            return null;
        }

        private void LoadQuestion()
        {
            if (CurrentQuestionIndex >= CurrentQuiz.Questions.Count)
            {
                var score = new PlayerScore
                {
                    PlayerName = PlayerName,
                    QuizTitle = CurrentQuiz.Title,
                    CorrectAnswers = CorrectAnswers,
                    TotalQuestions = CurrentQuiz.Questions.Count
                };

                QuizCompleted?.Invoke(score);

                MessageBox.Show($"Викторина завершена! Правильных ответов: {CorrectAnswers} из {CurrentQuiz.Questions.Count}.");
                this.Close();
                return;
            }

            var question = CurrentQuiz.Questions[CurrentQuestionIndex];
            QuestionText.Text = question.Text;

            // Обновляем список вариантов ответа
            AnswerOptions.ItemsSource = question.Options.OrderBy(_ => new Random().Next()).ToList();

            // Сбрасываем выбранный ответ
            SelectedAnswer = null;
            NextButton.IsEnabled = false;

            // Перезапуск таймера
            TimeLeft = 15;
            TimerText.Text = $"Осталось времени: {TimeLeft} сек";
            Timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            TimeLeft--;

            // Обновляем текст таймера
            TimerText.Text = $"Осталось времени: {TimeLeft} сек";

            if (TimeLeft <= 0)
            {
                Timer.Stop();

                // Если время вышло, засчитываем неправильный ответ и переходим к следующему вопросу
                MessageBox.Show("Время вышло!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                CurrentQuestionIndex++;
                LoadQuestion();
            }
        }

        private void AnswerSelected(object sender, RoutedEventArgs e)
        {
            // Получаем текст выбранного ответа
            SelectedAnswer = (sender as System.Windows.Controls.RadioButton)?.Content.ToString();

            // Активируем кнопку "Следующий вопрос"
            NextButton.IsEnabled = true;

            // Останавливаем таймер
            Timer.Stop();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Сравниваем выбранный ответ с правильным
            if (SelectedAnswer == CurrentQuiz.Questions[CurrentQuestionIndex].CorrectAnswer)
            {
                CorrectAnswers++;
            }

            // Переходим к следующему вопросу
            CurrentQuestionIndex++;
            LoadQuestion();
        }
    }
}
