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
        private int id;
        private readonly int userId;
        public InstructionMemoryViewModel(int userId, int id)
        {
            StartCommand = new Command(Start);
            BackCommand = new Command(Back);
            this.id = id;
            this.userId = userId;
        }

        public ICommand StartCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //начать тест
        private void Start()
        {
            Navigation.PushAsync(new MemoryQuestionsPage(userId, id));
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