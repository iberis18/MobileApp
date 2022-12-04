using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна подготовки к тестированию. Отображает имя, картинку и краткую инструкцию теста.
    internal class PreparingForTestViewModel : INotifyPropertyChanged
    {
        private readonly Test test;
        private readonly int userId;

        public PreparingForTestViewModel(int userId, int testId)
        {
            StartCommand = new Command(Start);
            BackCommand = new Command(Back);
            test = App.Database.GetTest(testId);
            this.userId = userId;
        }

        public ICommand StartCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public string Name => test.Name;
        public string Instruction => test.Instruction;

        public event PropertyChangedEventHandler PropertyChanged;

        //начать тест
        private void Start()
        {
            Navigation.PushAsync(new QuestionsPage(userId, test.Id, 0));
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