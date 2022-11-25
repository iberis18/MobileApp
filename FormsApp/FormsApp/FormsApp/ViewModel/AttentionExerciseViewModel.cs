using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    // vm окна упражнения на внимательность
    internal class AttentionExerciseViewModel : INotifyPropertyChanged
    {
        public const int n = 5;
        public int[,] array = new int [n,n];
        public int xNumber, yNumber;
        private string question;

        public AttentionExerciseViewModel()
        {
            StopCommand = new Command(Stop);
            Init();
            AddAnswers();
        }

        public ICommand StopCommand { get; }
        public INavigation Navigation { get; set; }

        //выводит текст вопроса
        public string Question
        {
            get => question;
            set
            {
                if (question != value)
                {
                    question = value;
                    OnPropertyChanged("Question");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<AnswerButton> ZeroColumn { get; set; } = new ObservableCollection<AnswerButton>();
        public ObservableCollection<AnswerButton> FirstColumn { get; set; } = new ObservableCollection<AnswerButton>();
        public ObservableCollection<AnswerButton> SecondColumn { get; set; } = new ObservableCollection<AnswerButton>();
        public ObservableCollection<AnswerButton> ThirdColumn { get; set; } = new ObservableCollection<AnswerButton>();
        public ObservableCollection<AnswerButton> FourthColumn { get; set; } = new ObservableCollection<AnswerButton>();


        public void Stop()
        {
            Navigation.PushAsync(new ExerciseCategoriesPage());
        }

        //проинициализировать список вариантов ответов 
        private void AddAnswers()
        {
            ZeroColumn.Clear();
            FirstColumn.Clear();
            SecondColumn.Clear();
            ThirdColumn.Clear();
            FourthColumn.Clear();

            for (var i = 0; i < n; i++)
            {
                ZeroColumn.Add(new AnswerButton(this) { Value = array[i, 0], Index = i, Color = "White" });
                FirstColumn.Add(new AnswerButton(this) { Value = array[i, 1], Index = i, Color = "White" });
                SecondColumn.Add(new AnswerButton(this) { Value = array[i, 2], Index = i, Color = "White" });
                ThirdColumn.Add(new AnswerButton(this) { Value = array[i, 3], Index = i, Color = "White" });
                FourthColumn.Add(new AnswerButton(this) { Value = array[i, 4], Index = i, Color = "White" });
            }
            Question = "Найдите число " + (array[xNumber, yNumber]).ToString();
        }

        private void Init()
        {
            int[] tmp = new int[n * n];
            for (int i = 0; i < n * n; i++)
                tmp[i] = i + 1;
            for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                array[i, j] = -1;

            Random random = new Random();
            int index;
            for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                do
                {
                    index = random.Next(n * n);
                    if (tmp[index] != -1)
                    {
                        array[i, j] = tmp[index];
                        tmp[index] = -1;
                    }
                } while (array[i, j] == -1);

            xNumber = random.Next(n);
            yNumber = random.Next(n);
        }

        public void NextQuestion()
        {
            //Navigation.PushAsync(new AttentionExercisePage());
            Init();
            AddAnswers();
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }



        //элемент варианта ответа
        public class AnswerButton : INotifyPropertyChanged
        {
            private readonly AttentionExerciseViewModel vm;
            private int index; //Номер 
            private int value; //значение 
            private string color; //цвет 

            public AnswerButton(AttentionExerciseViewModel vm)
            {
                AnswerCommand = new Command(Answer);
                this.vm = vm;
            }

            public ICommand AnswerCommand { get; }

            public int Value
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
            public int Index
            {
                get => index;
                set
                {
                    if (index != value)
                    {
                        index = value;
                        OnPropertyChanged("Index");
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

            private async void Answer(object sender)
            {
                if (int.Parse(sender?.ToString() ?? string.Empty) == vm.array[vm.xNumber, vm.yNumber])
                {
                    switch (vm.yNumber)
                    {
                        case 0: vm.ZeroColumn[vm.xNumber].Color = "#73C094"; break;
                        case 1: vm.FirstColumn[vm.xNumber].Color = "#73C094"; break;
                        case 2: vm.SecondColumn[vm.xNumber].Color = "#73C094"; break;
                        case 3: vm.ThirdColumn[vm.xNumber].Color = "#73C094"; break;
                        case 4: vm.FourthColumn[vm.xNumber].Color = "#73C094"; break;
                    }
                    await Task.Delay(700);
                    vm.NextQuestion();
                }
            }

            protected void OnPropertyChanged(string propName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}