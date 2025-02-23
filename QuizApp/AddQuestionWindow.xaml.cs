using System.Collections.Generic;
using System.Windows;

namespace QuizApp
{
    public partial class AddQuestionWindow : Window
    {
        public Question NewQuestion { get; private set; }

        public AddQuestionWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(QuestionTextBox.Text) ||
                string.IsNullOrWhiteSpace(CorrectAnswerTextBox.Text) ||
                string.IsNullOrWhiteSpace(OptionsTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Удаляем лишние символы и создаем список вариантов
            var options = new List<string>();
            foreach (var option in OptionsTextBox.Text.Split(new[] { "\r\n", "\n", "\r" }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                options.Add(option.Trim()); // Удаляем пробелы и другие лишние символы в начале/конце
            }

            // Создаем новый вопрос
            NewQuestion = new Question
            {
                Text = QuestionTextBox.Text.Trim(),
                CorrectAnswer = CorrectAnswerTextBox.Text.Trim(),
                Options = options
            };

            DialogResult = true;
            Close();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}