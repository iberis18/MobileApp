using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна помощи теста (подробно о тесте)
    internal class HelpTestViewModel : INotifyPropertyChanged
    {
        private readonly Test test;
        private readonly int userId;

        public HelpTestViewModel(int userId, int id)
        {
            GoToTestCommand = new Command(GoToTest);
            BackCommand = new Command(Back);
            test = App.Database.GetTest(id);
            this.userId = userId;
        }

        public ICommand GoToTestCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public string Name => test.Name;
        public string Help => test.Help;

        public event PropertyChangedEventHandler PropertyChanged;

        private void GoToTest()
        {
            Navigation.PushAsync(new TestPage(userId, test.Id));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}