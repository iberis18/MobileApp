using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using FormsApp.Model;
using FormsApp.View;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    class ResultsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Result result = new Result();

        public ICommand GoToExercisesCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }


        public ResultsViewModel()
        {
            GoToExercisesCommand = new Command(GoToExercises);
            BackCommand = new Command(Back);
        }

        public void Back()
        {
            Navigation.PopAsync();
        }

        public void GoToExercises()
        {
            Navigation.PushAsync(new ExerciseCategoriesPage());
        }

        public List<string> AllResults
        {
            get { return result.GetResults; }
        }
        public string Recommendations
        {
            get { return result.GetRecommendations; }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
