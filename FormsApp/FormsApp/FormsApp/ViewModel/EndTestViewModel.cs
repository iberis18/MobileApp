﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class EndTestViewModel : INotifyPropertyChanged
    {
        private Dictionary<int, int?> answers;
        private string testName;
        public EndTestViewModel(string testName, Dictionary<int, int?> answers)
        {
            GoToMenuCommand = new Command(GoToMenu);
            this.answers = answers;
            this.testName = testName;
        }

        public ICommand GoToMenuCommand { get; }
        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GoToMenu()
        {
            Navigation.PushAsync(new MenuPage());
        }
        public string Result => "ХХХ баллов";
        public string Comment
        {
            get
            {
                string s = "Тут будет выводиться расшифровка результатов. Пока что просто массив ответов:\n";
                foreach (var x in answers)
                    if (x.Value != -1 && x.Value != null)
                        s += "Вопрос №" + x.Key.ToString() + " — ответ " + x.Value.ToString() + '\n';
                    else
                        s += "Вопрос №" + x.Key.ToString() + " — нет ответа!" + '\n';
                return s;
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}