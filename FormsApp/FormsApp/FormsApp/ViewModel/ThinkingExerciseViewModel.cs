using System;
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

    internal class ThinkingExerciseViewModel : INotifyPropertyChanged
    {
        public readonly int currentQuestion;
        public readonly Exercise exercise;

        public ThinkingExerciseViewModel(string exName)
        {
            //AnswerCommand = new Command(Answer);
            StopCommand = new Command(Stop);
            exercise = new Exercise(exName);
            currentQuestion = new Random().Next(0, exercise.Questions.Count); //вопрос выбираем случайно
            AddAnswers();
        }

        public ThinkingExerciseViewModel(Exercise ex)
        {
            //AnswerCommand = new Command(Answer);
            StopCommand = new Command(Stop);
            exercise = ex;
            currentQuestion = new Random().Next(0, exercise.Questions.Count); //вопрос выбираем случайно
            AddAnswers();
        }

        //public ICommand AnswerCommand { get; }
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
            Navigation.PushAsync(new ThinkingExercisePage(exercise));
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
            private readonly ThinkingExerciseViewModel vm;
            private string color; //цвет
            private string value; //значение 

            public AnswerButton(ThinkingExerciseViewModel vm)
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
                if (vm.exercise.RightAnswer[vm.currentQuestion] % 2 == 0)
                    vm.LeftAnswers[vm.exercise.RightAnswer[vm.currentQuestion] / 2].Color = "#73C094";
                else
                    vm.RightAnswers[(vm.exercise.RightAnswer[vm.currentQuestion] - 1) / 2].Color = "#73C094";

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