using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна, отображающего список всех вопросов теста
    //позволяет переходить между вопросами и возвращаться к пропущенным

    internal class QuestionsMenuViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<int, int?> answers;
        private readonly Test test;
        private QuestionForMenu selectedQuestion;
        private readonly int userId;

        //передаем тест (с базой будет по id) и ответы пользователя
        public QuestionsMenuViewModel(int userId, int testId, Dictionary<int, int?> answers)
        {
            BackCommand = new Command(Back);
            CompleteCommand = new Command(Complete);
            test = App.Database.GetTest(testId);
            this.answers = answers;
            this.userId = userId;

            for (var i = 0; i < test.Questions.Count; i++) AllQuestions.Add(new QuestionForMenu(i, answers));
        }

        public ICommand BackCommand { get; }
        public ICommand CompleteCommand { get; }
        public INavigation Navigation { get; set; }


        public List<QuestionForMenu> AllQuestions { get; } = new List<QuestionForMenu>();

        //команда перехода к выбранному вопросу
        public QuestionForMenu SelectedQuestion
        {
            get => selectedQuestion;
            set
            {
                if (selectedQuestion != value)
                {
                    selectedQuestion = null;
                    OnPropertyChanged("SelectedQuestion");
                    Navigation.PushAsync(new QuestionsPage(userId, test.Id, value.Number, answers));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Back()
        {
            Navigation.PopAsync();
        }

        //завершить тест
        public void Complete()
        {
            Navigation.PushAsync(new EndTestPage(userId, test.Id, answers));
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        //вопросы с ответом — зеленый, пропущенные — красный, не просмотренные — белый.
        public class QuestionForMenu
        {
            public QuestionForMenu(int question, Dictionary<int, int?> answers)
            {
                Name = "Вопрос №" + (question + 1);
                Number = question;
                switch (answers[question])
                {
                    case -1:
                        Color = "White";
                        break;
                    case null:
                        Color = "#F64C72";
                        break;
                    default:
                        Color = "#73C094";
                        break;
                }
            }

            public string Color { get; set; }
            public string Name { get; set; }
            public int Number { get; set; }
        }
    }
}