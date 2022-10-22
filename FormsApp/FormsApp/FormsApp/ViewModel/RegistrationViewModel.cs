using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using FormsApp.Model;
using FormsApp.View;

namespace FormsApp.ViewModel
{
    class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string email = "", password = "", repeatPassword = "";

        public ICommand RegistrationCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public RegistrationViewModel()
        {
            RegistrationCommand = new Command(Registration);
            BackCommand = new Command(Back);
        }
         
        public void Registration()
        {
            //Добавление нового пользователя

            Navigation.PushAsync(new MainPage());
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
        public string RepeatPassword
        {
            get { return repeatPassword; }
            set
            {
                if (repeatPassword != value)
                {
                    repeatPassword = value;
                    OnPropertyChanged("RepeatPassword");
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
