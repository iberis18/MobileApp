using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна вопроса упражнений
    //основной функционал прохождения упражнений

    internal class MemoryAnswersViewModel : INotifyPropertyChanged
    {
        public readonly int currentQuestion;
        public readonly Exercise exercise;

        public MemoryAnswersViewModel(Exercise ex, int currentQuestion)
        {
            StopCommand = new Command(Stop);
            exercise = ex;
            this.currentQuestion = currentQuestion;
            AddAnswers();
        }

        public ICommand StopCommand { get; }
        public INavigation Navigation { get; set; }


        //выводит изображение вопроса
        public string QuestionImage => exercise.Questions[currentQuestion].Image;

        //выводит текст вопроса
        public string QuestionText => exercise.Questions[currentQuestion].Text;

        //выводит варианты ответа
        public ObservableCollection<AnswerButton> LeftAnswers { get; set; } = new ObservableCollection<AnswerButton>();
        public ObservableCollection<AnswerButton> RightAnswers { get; set; } = new ObservableCollection<AnswerButton>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void Stop()
        {
            Navigation.PushAsync(new ExerciseCategoriesPage());
        }

        public void NextQuestion()
        {
            Navigation.PushAsync(new MemoryQuestionsPage(exercise.Id));
        }

        //проинициализировать список вариантов ответов 
        private void AddAnswers()
        {
            for (var i = 0; i < exercise.Questions[currentQuestion].Answers.Count; i += 2)
                LeftAnswers.Add(new AnswerButton(this)
                    { Value = exercise.Questions[currentQuestion].Answers[i].Text, Color = "#F64C72" });

            for (var i = 1; i < exercise.Questions[currentQuestion].Answers.Count; i += 2)
                RightAnswers.Add(new AnswerButton(this)
                    { Value = exercise.Questions[currentQuestion].Answers[i].Text, Color = "#F64C72" });
        }


        //элемент варианта ответа
        public class AnswerButton : INotifyPropertyChanged
        {
            private readonly MemoryAnswersViewModel vm;
            private string color; //цвет
            private string value; //значение 

            public AnswerButton(MemoryAnswersViewModel vm)
            {
                AnswerCommand = new Command(Answer);
                this.vm = vm;
            }

            public ICommand AnswerCommand { get; }

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

            public string Color
            {
                get => color;
                set
                {
                    if (color != value)
                    {
                        color = value;
                        OnPropertyChanged("Color");
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private async void Answer()
            {
                for (int i = 0; i < vm.exercise.Questions[vm.currentQuestion].Answers.Count; i++)
                {
                    if (vm.exercise.Questions[vm.currentQuestion].Answers[i].isTrue)
                        if (i % 2 == 0)
                            vm.LeftAnswers[i / 2].Color = "#73C094";
                        else
                            vm.RightAnswers[(i - 1) / 2].Color = "#73C094";
                }

                await Task.Delay(700);
                vm.NextQuestion();
            }

            protected void OnPropertyChanged(string propName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}