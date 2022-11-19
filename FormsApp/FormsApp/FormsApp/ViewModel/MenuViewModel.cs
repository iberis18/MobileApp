using System.ComponentModel;
using System.Windows.Input;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class MenuViewModel : INotifyPropertyChanged
    {
        public MenuViewModel()
        {
            LogOutCommand = new Command(LogOut);
            GoToTestsCommand = new Command(GoToTests);
            GoToExercisesCommand = new Command(GoToExercises);
            GoToResultsCommand = new Command(GoToResults);
            GoToHelpCommand = new Command(GoToHelp);
        }

        public ICommand LogOutCommand { get; }
        public ICommand GoToTestsCommand { get; }
        public ICommand GoToExercisesCommand { get; }
        public ICommand GoToResultsCommand { get; }
        public ICommand GoToHelpCommand { get; }

        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void LogOut()
        {
            Navigation.PushAsync(new MainPage());
        }

        public void GoToTests()
        {
            Navigation.PushAsync(new TestCategoriesPage());
        }

        public void GoToExercises()
        {
            Navigation.PushAsync(new ExerciseCategoriesPage());
        }

        public void GoToResults()
        {
            Navigation.PushAsync(new ResultsPage());
        }

        public void GoToHelp()
        {
            Navigation.PushAsync(new HelpPage());
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}