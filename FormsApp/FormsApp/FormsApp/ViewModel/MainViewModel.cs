using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //стартовое окно. Предлагает вход/регистрацию
    internal class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            LoginCommand = new Command(Login);
            RegistrationCommand = new Command(Registration);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegistrationCommand { get; }
        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void Login()
        {
            Navigation.PushAsync(new LoginPage());
        }

        public void Registration()
        {
            Navigation.PushAsync(new RegistrationPage());
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}