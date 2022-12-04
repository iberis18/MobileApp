using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    // vm окна, вызываемого при завершении теста
    internal class EndTestViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<int, int?> answers; //ответы пользователя
        private readonly Test test;
        private string result = "";
        private string comment = "";
        private readonly int userId;
        private int sum = 0;

        public EndTestViewModel(int userId, int testId, Dictionary<int, int?> answers)
        {
            this.userId = userId;
            GoToMenuCommand = new Command(GoToMenu);
            this.answers = answers;
            this.test = App.Database.GetTest(testId);

            ResultsProcessing();
        }

        public ICommand GoToMenuCommand { get; }
        public INavigation Navigation { get; set; }
        public string Result
        {
            get => result;
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged("Result");
                }
            }
        }

        public string Comment
        {
            get => comment;
            set
            {
                if (comment != value)
                {
                    comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GoToMenu()
        {
            Navigation.PushAsync(new MenuPage(userId));
        }

        private void ResultsProcessing()
        {
            foreach (var x in answers)
            {
                if (x.Value != null && x.Value != -1)
                    if (test.Questions[x.Key].Answers[(int)x.Value].isTrue)
                        sum++;
            }

            //результат с учетом числа
            if (sum % 100 >= 10 && sum % 100 < 20 )
                Result = sum.ToString() + " баллов";
            else
                switch (sum % 10)
                {
                    case 1: Result = sum.ToString() + " балл"; break;
                    case 2: case 3: case 4: Result = sum.ToString() + " балла"; break;
                    case 5: case 6: case 7: case 8: case 9: case 0: Result = sum.ToString() + " баллов"; break;
                }

            foreach (var x in test.Norms)
            {
                if (sum >= x.Min && sum < x.Max)
                {
                    Comment = x.Text;
                    break;
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}