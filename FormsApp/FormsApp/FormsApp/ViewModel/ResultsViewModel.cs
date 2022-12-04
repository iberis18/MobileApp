using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна вывода результатов и рекомендаций
    internal class ResultsViewModel : INotifyPropertyChanged
    {
        private readonly IEnumerable<Result> results;
        private readonly int userId;

        public ResultsViewModel(int userId)
        {
            this.userId = userId;
            GoToExercisesCommand = new Command(GoToExercises);
            BackCommand = new Command(Back);
            results = App.Database.GetResults();
        }

        public ICommand GoToExercisesCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public List<Result> AllResults => results.ToList();

        public string Recommendations => "recommendation";

        //TODO recommendation BL

        public event PropertyChangedEventHandler PropertyChanged;

        public void Back()
        {
            Navigation.PopAsync();
        }

        public void GoToExercises()
        {
            Navigation.PushAsync(new ExerciseCategoriesPage(userId));
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}