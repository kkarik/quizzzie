using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace QuizApp
{
    public partial class EditQuizWindow : Window
    {
        public Quiz EditedQuiz { get; private set; }

        public EditQuizWindow(Quiz quiz)
        {
            InitializeComponent();
            EditedQuiz = quiz;

            TitleTextBox.Text = quiz.Title;
            QuestionsDataGrid.ItemsSource = new ObservableCollection<Question>(quiz.Questions);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            EditedQuiz.Title = TitleTextBox.Text;
            EditedQuiz.Questions = new List<Question>(QuestionsDataGrid.ItemsSource as ObservableCollection<Question>);
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }


        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новое окно для ввода данных нового вопроса
            var addQuestionWindow = new AddQuestionWindow();
            if (addQuestionWindow.ShowDialog() == true)
            {
                // Получаем новый вопрос из окна и добавляем его в таблицу
                var questions = QuestionsDataGrid.ItemsSource as ObservableCollection<Question>;
                if (questions != null)
                {
                    questions.Add(addQuestionWindow.NewQuestion);
                }
            }
        }


        private void EditOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.Tag is Question selectedQuestion)
            {
                // Преобразуем List<string> в ObservableCollection<Option> с помощью LINQ
                var options = new ObservableCollection<Option>(
                    selectedQuestion.Options.Select(option => new Option(option))
                );

                var optionsWindow = new EditOptionsWindow(options);
                if (optionsWindow.ShowDialog() == true)
                {
                    // Преобразуем обратно ObservableCollection<Option> в List<string>
                    selectedQuestion.Options = optionsWindow.Options.Select(option => option.Name).ToList();
                    QuestionsDataGrid.Items.Refresh();
                }
            }
        }

}
}