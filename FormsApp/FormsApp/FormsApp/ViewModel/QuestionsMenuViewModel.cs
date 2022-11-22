using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class QuestionsMenuViewModel : INotifyPropertyChanged
    {
        private readonly Test test;
        private List<QuestionForMenu> allQuestions = new List<QuestionForMenu>();
        private QuestionForMenu selectedQuestion = null;
        private Dictionary<int, int?> answers;

        public QuestionsMenuViewModel(string testName, Dictionary<int, int?> answers)
        {
            BackCommand = new Command(Back);
            test = new Test(testName);
            this.answers = answers;

            for (int i = 0; i < test.Questions.Count; i++)
            {
                allQuestions.Add(new QuestionForMenu(i, answers));
            }
        }

        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public List<QuestionForMenu> AllQuestions => allQuestions;
        public QuestionForMenu SelectedQuestion
        {
            get => selectedQuestion;
            set
            {
                if (selectedQuestion != value)
                {
                    selectedQuestion = null;
                    OnPropertyChanged("SelectedQuestion");
                    Navigation.PushAsync(new QuestionsPage(test.Name, value.Number, answers));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Back()
        {
            Navigation.PopAsync();
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        public class QuestionForMenu
        {
            public string Color { get; set; }
            public string Name { get; set; }
            public int Number { get; set; }

            public QuestionForMenu(int question, Dictionary<int, int?> answers)
            {
                Name = "Вопрос №" + (question + 1).ToString();
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
        }
    }
}