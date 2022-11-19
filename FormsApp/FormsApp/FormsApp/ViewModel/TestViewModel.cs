using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class TestViewModel : INotifyPropertyChanged
    {
        private readonly Test test;
        public TestViewModel(string testName)
        {
            StartTestCommand = new Command(StartTest);
            BackCommand = new Command(Back);
            HelpCommand = new Command(Help);
            test = new Test(testName);
        }

        public ICommand StartTestCommand { get; }
        public ICommand HelpCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public string Name => test.Name;
        public string Image => test.Image;

        public event PropertyChangedEventHandler PropertyChanged;

        private void StartTest()
        {
            Navigation.PushAsync(new PreparingForTestPage(test.Name));
        }
        private void Help()
        {
            Navigation.PushAsync(new HelpTestPage(test.Name));
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