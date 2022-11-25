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
        private string name;
        public InstructionMemoryViewModel(string name)
        {
            StartCommand = new Command(Start);
            BackCommand = new Command(Back);
            this.name = name;
        }

        public ICommand StartCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //начать тест
        private void Start()
        {
            Navigation.PushAsync(new MemoryQuestionsPage(name));
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