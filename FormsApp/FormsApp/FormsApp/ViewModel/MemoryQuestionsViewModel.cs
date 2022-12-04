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
        private readonly int userId;

        public MemoryQuestionsViewModel(int userId, int id)
        {
            exercise = App.Database.GetExercise(id);
            this.userId = userId;
            currentQuestion = new Random().Next(0, exercise.Questions.Count); //вопрос выбираем случайно
            ShowAnswers();
        }

        public MemoryQuestionsViewModel(int userId, Exercise ex)
        {
            exercise = ex;
            this.userId = userId;
            currentQuestion = new Random().Next(0, exercise.Questions.Count); //вопрос выбираем случайно
            ShowAnswers();
        }

        public INavigation Navigation { get; set; }


        //выводит изображение вопроса
        public string QuestionImage => exercise.Questions[currentQuestion].ExerciseImage;

        public event PropertyChangedEventHandler PropertyChanged;

        private async void ShowAnswers()
        {
            await Task.Delay(3000);
            Navigation.PushAsync(new MemoryAnswersPage(userId, exercise, currentQuestion));
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}