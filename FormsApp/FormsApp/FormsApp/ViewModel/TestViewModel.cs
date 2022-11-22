using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна теста
    //находи тест по имени (с бд будет по id)

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

        public string Name => test.Name; //название теста
        public string Image => test.Image; //изображение теста

        public event PropertyChangedEventHandler PropertyChanged;

        //команда начать тест
        private void StartTest()
        {
            Navigation.PushAsync(new PreparingForTestPage(test.Name));
        }
        //вызов справки 
        private void Help()
        {
            Navigation.PushAsync(new HelpTestPage(test.Name));
        }
        //назад
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