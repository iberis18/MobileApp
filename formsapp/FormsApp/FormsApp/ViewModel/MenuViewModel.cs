using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна главного меню программы
    internal class MenuViewModel : INotifyPropertyChanged
    {
        private readonly int userId;
        public MenuViewModel(int userId)
        {
            this.userId = userId;
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

        //выйти
        public void LogOut()
        {
            Navigation.PushAsync(new MainPage());
        }

        //перейти к тестам
        public void GoToTests()
        {
            Navigation.PushAsync(new TestCategoriesPage(userId));
        }

        //перейти к упражнениям
        public void GoToExercises()
        {
            Navigation.PushAsync(new ExerciseCategoriesPage(userId));
        }

        //перейти к результатам
        public void GoToResults()
        {
            Navigation.PushAsync(new ResultsPage(userId));
        }

        //вызвать справку
        public void GoToHelp()
        {
            Navigation.PushAsync(new HelpPage(userId));
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}