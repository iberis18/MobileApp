using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class QuestionsViewModel : INotifyPropertyChanged
    {
        private readonly Test test;
        private readonly int currentQuestion;
        private ObservableCollection<RadioElement> leftAnswerImages = new ObservableCollection<RadioElement>();
        private ObservableCollection<RadioElement> rightAnswerImages = new ObservableCollection<RadioElement>();
        private ObservableCollection<RadioElement> answerTexts = new ObservableCollection<RadioElement>();
        private Dictionary<int, int?> answers;

        public QuestionsViewModel(string testName, int currentQuestion)
        {
            SkipCommand = new Command(Skip);
            AnswerCommand = new Command(Answer);
            OpenMenuCommand = new Command(OpenMenu);
            test = new Test(testName);
            this.currentQuestion = currentQuestion;
            AddAnswers();
            answers = new Dictionary<int, int?>();
            for (int i = 0; i < test.Questions.Count; i++)
                answers[i] = -1;
        }
        public QuestionsViewModel(string testName, int currentQuestion, Dictionary<int, int?> answers)
        {
            SkipCommand = new Command(Skip);
            AnswerCommand = new Command(Answer);
            OpenMenuCommand = new Command(OpenMenu);
            test = new Test(testName);
            this.currentQuestion = currentQuestion;
            AddAnswers();
            this.answers = answers;
        }


        public ICommand SkipCommand { get; }
        public ICommand AnswerCommand { get; }
        public ICommand OpenMenuCommand { get; }
        public INavigation Navigation { get; set; }

        public string Number => "Вопрос №" + (currentQuestion + 1).ToString();
        public string QuestionImage => test.Questions[currentQuestion].Image;
        public string QuestionText => test.Questions[currentQuestion].Text;

        public ObservableCollection<RadioElement> LeftAnswerImages
        {
            get => leftAnswerImages;
            set
            {
                if (answerTexts != value)
                {
                    answerTexts = value;
                    OnPropertyChanged("Checked");
                }
            }
        }

        public ObservableCollection<RadioElement> RightAnswerImages
        {
            get => rightAnswerImages;
            set
            {
                if (answerTexts != value)
                {
                    answerTexts = value;
                    OnPropertyChanged("RightAnswerImages");
                }
            }
        }

        public ObservableCollection<RadioElement> AnswerTexts
        {
            get => answerTexts;
            set
            {
                if (answerTexts != value)
                {
                    answerTexts = value;
                    OnPropertyChanged("Checked");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Skip()
        {
            answers[currentQuestion] = null;
            NextQuestionOrFinish();
        }

        private void Answer()
        {
            CheckAnswer();
            NextQuestionOrFinish();
        }

        private void NextQuestionOrFinish()
        {
            if (currentQuestion < test.Questions.Count - 1)
                Navigation.PushAsync(new QuestionsPage(test.Name, currentQuestion + 1, answers));
            else
                HaveUnunsweredQuestion();
        }

        private void HaveUnunsweredQuestion()
        {
            if (answers.Any(x => x.Value == -1 || x.Value == null))
                Navigation.PushAsync(new HaveUnansweredQuestionsPage(test.Name, answers));
            else
                Navigation.PushAsync(new EndTestPage(test.Name, answers));
        }

        private void OpenMenu()
        {
            Navigation.PushAsync(new QuestionsMenuPage(test.Name, answers));
        }

        private void AddAnswers()
        {
            for (var i = 0; i < test.Questions[currentQuestion].Answers.Count; i += 2)
                if (test.Questions[currentQuestion].Answers[i].Image != "")
                    leftAnswerImages.Add(new RadioElement()
                        { Checked = false, Value = test.Questions[currentQuestion].Answers[i].Image });

            for (var i = 1; i < test.Questions[currentQuestion].Answers.Count; i += 2)
                if (test.Questions[currentQuestion].Answers[i].Image != "")
                    rightAnswerImages.Add(new RadioElement()
                        { Checked = false, Value = test.Questions[currentQuestion].Answers[i].Image });

            foreach (var t in test.Questions[currentQuestion].Answers)
                if (t.Text != "")
                    answerTexts.Add(new RadioElement() { Checked = false, Value = t.Text });
        }

        private void CheckAnswer()
        {
            for (var index = 0; index < leftAnswerImages.Count; index++)
                if (leftAnswerImages[index].Checked == true)
                {
                    answers[currentQuestion] = index * 2;
                    return;
                }
            for (var index = 0; index < rightAnswerImages.Count; index++)
                if (rightAnswerImages[index].Checked == true)
                {
                    answers[currentQuestion] = index * 2 + 1;
                    return;
                }
            for (var index = 0; index < answerTexts.Count; index++)
                if (answerTexts[index].Checked == true)
                {
                    answers[currentQuestion] = index;
                    return;
                }
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        public class RadioElement : INotifyPropertyChanged
        {
            private string value;
            private bool check;

            public string Value
            {
                get => value;
                set
                {
                    if (this.value != value)
                    {
                        this.value = value;
                        OnPropertyChanged("Value");
                    }
                }
            }

            public bool Checked
            {
                get => check;
                set
                {
                    if (check != value)
                    {
                        check = value;
                        OnPropertyChanged("Checked");
                    }
                }
            }

            protected void OnPropertyChanged(string propName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}