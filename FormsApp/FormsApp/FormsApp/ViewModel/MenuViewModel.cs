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
    class MenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LogOutCommand { get; }
        public ICommand GoToTestsCommand { get; }
        public ICommand GoToExercisesCommand { get; }
        public ICommand GoToResultsCommand { get; }
        public ICommand GoToHelpCommand { get; }

        public INavigation Navigation { get; set; }

        public MenuViewModel()
        {
            LogOutCommand = new Command(LogOut);
            GoToTestsCommand = new Command(GoToTests);
            GoToExercisesCommand = new Command(GoToExercises);
            GoToResultsCommand = new Command(GoToResults);
            GoToHelpCommand = new Command(GoToHelp);
        }

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
