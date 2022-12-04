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
    //vm окна вопроса
    //основной функционал прохождения теста

    internal class QuestionsViewModel : INotifyPropertyChanged
    {
        private readonly int currentQuestion;
        private readonly Test test;
        private readonly int userId;
        private readonly Dictionary<int, int?> answers;
        private ObservableCollection<RadioElement> answerTexts = new ObservableCollection<RadioElement>();
        private readonly ObservableCollection<RadioElement> leftAnswerImages = new ObservableCollection<RadioElement>();

        private readonly ObservableCollection<RadioElement>
            rightAnswerImages = new ObservableCollection<RadioElement>();

        //для первого вопроса. Создаем и инициализируем ответы пользователя
        public QuestionsViewModel(int userId, int testId, int currentQuestion)
        {
            SkipCommand = new Command(Skip);
            AnswerCommand = new Command(Answer);
            OpenMenuCommand = new Command(OpenMenu);
            test = App.Database.GetTest(testId);
            this.userId = userId;

            this.currentQuestion = currentQuestion;
            AddAnswers();
            answers = new Dictionary<int, int?>();
            for (var i = 0; i < test.Questions.Count; i++)
                answers[i] = -1;
        }

        //для остальных вопросов 
        //хранит предыдущие ответы пользователя
        public QuestionsViewModel(int userId, int testId, int currentQuestion, Dictionary<int, int?> answers)
        {
            SkipCommand = new Command(Skip);
            AnswerCommand = new Command(Answer);
            OpenMenuCommand = new Command(OpenMenu);
            test = App.Database.GetTest(testId);
            this.userId = userId;

            this.currentQuestion = currentQuestion;
            AddAnswers();
            this.answers = answers;
        }


        public ICommand SkipCommand { get; }
        public ICommand AnswerCommand { get; }
        public ICommand OpenMenuCommand { get; }
        public INavigation Navigation { get; set; }

        //выводит заголовок
        public string Number => "Вопрос №" + (currentQuestion + 1);

        //выводит изображение вопроса
        public string QuestionImage => test.Questions[currentQuestion].Image;

        //выводит текст вопроса
        public string QuestionText => test.Questions[currentQuestion].Text;

        //выводит варианты ответа
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

        //выводит варианты ответа
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

        //выводит варианты ответа
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

        //пропустить вопрос
        private void Skip()
        {
            answers[currentQuestion] = null;
            NextQuestionOrFinish();
        }

        //ответить на вопрос
        private void Answer()
        {
            CheckAnswer();
            NextQuestionOrFinish();
        }

        //проверить, существует ли следующий вопрос, или пора завершать тест
        private void NextQuestionOrFinish()
        {
            if (currentQuestion < test.Questions.Count - 1)
                Navigation.PushAsync(new QuestionsPage(userId, test.Id, currentQuestion + 1, answers));
            else
                HaveUnunsweredQuestion();
        }

        //проверяет, остались ли вопросы без ответа
        private void HaveUnunsweredQuestion()
        {
            if (answers.Any(x => x.Value == -1 || x.Value == null))
                Navigation.PushAsync(new HaveUnansweredQuestionsPage(userId, test.Id, answers));
            else
                Navigation.PushAsync(new EndTestPage(userId, test.Id, answers));
        }

        //открыть список вопросов
        private void OpenMenu()
        {
            Navigation.PushAsync(new QuestionsMenuPage(userId, test.Id, answers));
        }

        //проинициализировать список вариантов ответов 
        private void AddAnswers()
        {
            for (var i = 0; i < test.Questions[currentQuestion].Answers.Count; i += 2)
                if (test.Questions[currentQuestion].Answers[i].Image != "")
                    leftAnswerImages.Add(new RadioElement
                        { Checked = false, Value = test.Questions[currentQuestion].Answers[i].Image });

            for (var i = 1; i < test.Questions[currentQuestion].Answers.Count; i += 2)
                if (test.Questions[currentQuestion].Answers[i].Image != "")
                    rightAnswerImages.Add(new RadioElement
                        { Checked = false, Value = test.Questions[currentQuestion].Answers[i].Image });

            foreach (var t in test.Questions[currentQuestion].Answers)
                if (t.Text != "")
                    answerTexts.Add(new RadioElement { Checked = false, Value = t.Text });
        }

        //найти выбранный вариант ответа и запомнить его
        private void CheckAnswer()
        {
            for (var index = 0; index < leftAnswerImages.Count; index++)
                if (leftAnswerImages[index].Checked)
                {
                    answers[currentQuestion] = index * 2;
                    return;
                }

            for (var index = 0; index < rightAnswerImages.Count; index++)
                if (rightAnswerImages[index].Checked)
                {
                    answers[currentQuestion] = index * 2 + 1;
                    return;
                }

            for (var index = 0; index < answerTexts.Count; index++)
                if (answerTexts[index].Checked)
                {
                    answers[currentQuestion] = index;
                    return;
                }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        //элемент варианта ответа radiobutton 
        public class RadioElement : INotifyPropertyChanged
        {
            private bool check; //выбран или нет
            private string value; //значение 

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

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}