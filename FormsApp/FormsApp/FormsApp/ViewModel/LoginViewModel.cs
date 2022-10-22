using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using FormsApp.Model;
using FormsApp.View;

namespace FormsApp.ViewModel
{
    class LoginViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string email = "", password = "";

        public ICommand LoginCommand { get; }
        public ICommand RecoveryPasswordCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            RecoveryPasswordCommand = new Command(RecoveryPassword);
            BackCommand = new Command(Back);
        }

        public void Login()
        {
            //проверка правильности имени пользователя и пароля

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
        public string Email
        {
            get { return email; }
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
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
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
