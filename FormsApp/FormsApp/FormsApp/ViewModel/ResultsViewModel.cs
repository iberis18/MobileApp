using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class ResultsViewModel : INotifyPropertyChanged
    {
        private readonly Result result = new Result();


        public ResultsViewModel()
        {
            GoToExercisesCommand = new Command(GoToExercises);
            BackCommand = new Command(Back);
        }

        public ICommand GoToExercisesCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public List<string> AllResults => result.GetResults;

        public string Recommendations => result.GetRecommendations;

        public event PropertyChangedEventHandler PropertyChanged;

        public void Back()
        {
            Navigation.PopAsync();
        }

        public void GoToExercises()
        {
            Navigation.PushAsync(new ExerciseCategoriesPage());
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}