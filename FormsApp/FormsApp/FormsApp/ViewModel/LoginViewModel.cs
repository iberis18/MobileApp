﻿using System.ComponentModel;
using System.Windows.Input;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private string email = "", password = "";

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            RecoveryPasswordCommand = new Command(RecoveryPassword);
            BackCommand = new Command(Back);
        }

        public ICommand LoginCommand { get; }
        public ICommand RecoveryPasswordCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Login()
        {
            //проверка правильности имени пользователя и пароля
            //await DisplayAlert("Неудача!", "Неправильное имя пользователя или пароль! Попробуйте еще раз!", "OK");
            Navigation.PushAsync(new MenuPage());
        }

        public void RecoveryPassword()
        {
            Navigation.PushAsync(new RecoveryPasswordPage());
        }

        public void Back()
        {
            Navigation.PopAsync();
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}