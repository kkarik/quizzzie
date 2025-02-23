using System.Collections.ObjectModel;
using System.Windows;

namespace QuizApp
{
    public partial class EditOptionsWindow : Window
    {
        public ObservableCollection<Option> Options { get; private set; }

        public EditOptionsWindow(ObservableCollection<Option> options)
        {
            InitializeComponent();
            Options = options;
            OptionsDataGrid.ItemsSource = Options;
        }

        private void AddOption_Click(object sender, RoutedEventArgs e)
        {
            Options.Add(new Option("Новый вариант"));
        }

        private void RemoveOption_Click(object sender, RoutedEventArgs e)
        {
            if (OptionsDataGrid.SelectedItem is Option selectedOption)
            {
                Options.Remove(selectedOption);
            }
            else
            {
                MessageBox.Show("Выберите вариант для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}