using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна подготовки к тестированию. Отображает имя, картинку и краткую инструкцию теста.
    internal class InstructionMemoryViewModel : INotifyPropertyChanged
    {
        private readonly Test test;
        public InstructionMemoryViewModel()
        {
            StartCommand = new Command(Start);
            BackCommand = new Command(Back);
        }

        public ICommand StartCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //начать тест
        private void Start()
        {
            //Navigation.PushAsync(new QuestionsPage(test.Name, 0));
            //TODO открытие страницы с тренажером памяти
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