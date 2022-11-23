using System;
using System.ComponentModel;
using System.Threading.Tasks;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна вопроса упражнения на память

    internal class MemoryQuestionsViewModel : INotifyPropertyChanged
    {
        public readonly int currentQuestion;
        public readonly Exercise exercise;

        public MemoryQuestionsViewModel(string exName)
        {
            exercise = new Exercise(exName);
            currentQuestion = new Random().Next(0, exercise.Questions.Count); //вопрос выбираем случайно
            ShowAnswers();
        }

        public MemoryQuestionsViewModel(Exercise ex)
        {
            exercise = ex;
            currentQuestion = new Random().Next(0, exercise.Questions.Count); //вопрос выбираем случайно
            ShowAnswers();
        }

        public INavigation Navigation { get; set; }


        //выводит изображение вопроса
        public string QuestionImage => exercise.MainImage[currentQuestion];

        public event PropertyChangedEventHandler PropertyChanged;

        private async void ShowAnswers()
        {
            await Task.Delay(3000);
            Navigation.PushAsync(new MemoryAnswersPage(exercise, currentQuestion));
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}