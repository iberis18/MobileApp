﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    // vm окна, вызываемого при завершении теста
    internal class EndTestViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<int, int?> answers; //ответы пользователя
        private int test;
        private readonly int userId;

        public EndTestViewModel(int userId, int testId, Dictionary<int, int?> answers)
        {
            this.userId = userId;
            GoToMenuCommand = new Command(GoToMenu);
            this.answers = answers;
            this.test = testId;
        }

        public ICommand GoToMenuCommand { get; }
        public INavigation Navigation { get; set; }
        public string Result => "ХХХ баллов";

        public string Comment
        {
            get
            {
                var s = "Тут будет выводиться расшифровка результатов. Пока что просто массив ответов:\n";
                foreach (var x in answers)
                    if (x.Value != -1 && x.Value != null)
                        s += "Вопрос №" + x.Key + " — ответ " + x.Value + '\n';
                    else
                        s += "Вопрос №" + x.Key + " — нет ответа!" + '\n';
                return s;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GoToMenu()
        {
            Navigation.PushAsync(new MenuPage(userId));
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}