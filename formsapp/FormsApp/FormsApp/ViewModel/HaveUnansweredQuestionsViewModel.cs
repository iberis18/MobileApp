using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm Окна, вызываемого если есть вопросы без ответа
    internal class HaveUnansweredQuestionsViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<int, int?> answers;
        private readonly int test;

        public HaveUnansweredQuestionsViewModel(int testId, Dictionary<int, int?> answers)
        {
            OpenMenuCommand = new Command(OpenMenu);
            CompleteCommand = new Command(Complete);
            this.answers = answers;
            this.test = testId;
        }

        public ICommand OpenMenuCommand { get; }
        public ICommand CompleteCommand { get; }
        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OpenMenu()
        {
            Navigation.PushAsync(new QuestionsMenuPage(test, answers));
        }

        public void Complete()
        {
            Navigation.PushAsync(new EndTestPage(test, answers));
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}