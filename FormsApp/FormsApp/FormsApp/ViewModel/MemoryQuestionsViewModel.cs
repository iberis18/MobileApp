using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна вопроса упражнения на память

    internal class MemoryQuestionsViewModel : INotifyPropertyChanged
    {
        public readonly Exercise exercise;
        public readonly int currentQuestion;

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
        private async void ShowAnswers()
        {
            await Task.Delay(3000);
            Navigation.PushAsync(new MemoryAnswersPage(exercise, currentQuestion));
        }
        public INavigation Navigation { get; set; }


        //выводит изображение вопроса
        public string QuestionImage => exercise.MainImage[currentQuestion];

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}