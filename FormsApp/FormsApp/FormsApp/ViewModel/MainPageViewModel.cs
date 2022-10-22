﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using FormsApp.Model;
using FormsApp.View;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    class MainPageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //private Phone phone;

        public ICommand LoginCommand { get; }
        public ICommand RegistrationCommand { get; }
        public INavigation Navigation { get; set; }

        public MainPageViewModel()
        {
            LoginCommand = new Command(Login);
            RegistrationCommand = new Command(Registration);
        }

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
