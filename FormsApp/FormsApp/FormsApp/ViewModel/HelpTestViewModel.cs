using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class HelpTestViewModel : INotifyPropertyChanged
    {
        private readonly Test test;
        public HelpTestViewModel(string testName)
        {
            GoToTestCommand = new Command(GoToTest);
            BackCommand = new Command(Back);
            test = new Test(testName);
        }

        public ICommand GoToTestCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public string Name => test.Name;
        public string Help => test.Help;

        public event PropertyChangedEventHandler PropertyChanged;

        private void GoToTest()
        {
            Navigation.PushAsync(new TestPage(test.Name));
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