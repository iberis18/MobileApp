using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class QuestionsViewModel : INotifyPropertyChanged
    {
        private readonly Test test;
        private int currentQuestion;
        private string selectedAnswerImage = null, selectedAnswerText = null;

        public QuestionsViewModel(string testName, int currentQuestion)
        {
            SkipCommand = new Command(Skip);
            AnswerCommand = new Command(Answer);
            OpenMenuCommand = new Command(OpenMenu);
            test = new Test(testName);
            this.currentQuestion = currentQuestion;
        }

        public ICommand SkipCommand { get; }
        public ICommand AnswerCommand { get; }
        public ICommand OpenMenuCommand { get; }
        public INavigation Navigation { get; set; }

        public string Number => "Вопрос №" + (currentQuestion + 1).ToString();
        public string QuestionImage => test.Questions[currentQuestion].Image;
        public string QuestionText => test.Questions[currentQuestion].Text;

        public List<string> LeftAnswerImages
        {
            get
            {
                var list = new List<string>();
                for (var i = 0; i < test.Questions[currentQuestion].Answers.Count; i += 2)
                    if (test.Questions[currentQuestion].Answers[i].Image != "")
                        list.Add(test.Questions[currentQuestion].Answers[i].Image);
                return list;
            }
        }
        
        public List<string> RightAnswerImages
        {
            get
            {
                var list = new List<string>();
                for (var i = 1; i < test.Questions[currentQuestion].Answers.Count; i += 2)
                    if (test.Questions[currentQuestion].Answers[i].Image != "")
                        list.Add(test.Questions[currentQuestion].Answers[i].Image);
                return list;
            }
        }
        
        public List<string> AnswerTexts
        {
            get
            {
                var list = new List<string>();
                foreach (var t in test.Questions[currentQuestion].Answers)
                    if (t.Text != "")
                        list.Add(t.Text);

                return list;
            }
        }
        
        public string SelectedAnswerImage
        {
            get => selectedAnswerImage;
            set
            {
                if (selectedAnswerImage != value)
                {
                    selectedAnswerImage = value;
                    OnPropertyChanged("SelectedAnswerImage");
                }
            }
        }

        public string SelectedAnswerText
        {
            get => selectedAnswerText;
            set
            {
                if (selectedAnswerText != value)
                {
                    selectedAnswerText = value;
                    OnPropertyChanged("SelectedAnswerText");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Skip()
        {
            //currentQuestion++;
            if (currentQuestion < test.Questions.Count - 1)
                Navigation.PushAsync(new QuestionsPage(test.Name, currentQuestion + 1));
        }

        private void Answer()
        {
            //Запись ответа
            //currentQuestion++;
            if (currentQuestion < test.Questions.Count - 1)
                Navigation.PushAsync(new QuestionsPage(test.Name, currentQuestion + 1));
        }

        private void OpenMenu()
        {
            
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}