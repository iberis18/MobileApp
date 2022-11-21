using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class PreparingForTestViewModel : INotifyPropertyChanged
    {
        private readonly Test test;
        public PreparingForTestViewModel(string testName)
        {
            StartCommand = new Command(Start);
            BackCommand = new Command(Back);
            test = new Test(testName);
        }

        public ICommand StartCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public string Name => test.Name;
        public string Instruction => test.Instruction;

        public event PropertyChangedEventHandler PropertyChanged;

        private void Start()
        {
            Navigation.PushAsync(new QuestionsPage(test.Name, 0));
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