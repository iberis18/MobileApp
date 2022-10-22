using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using FormsApp.Model;
using FormsApp.View;

namespace FormsApp.ViewModel
{
    class RecoveryPasswordViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string email = "";
        public ICommand RecoveryPasswordCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public RecoveryPasswordViewModel()
        {
            RecoveryPasswordCommand = new Command(RecoveryPassword);
            BackCommand = new Command(Back);
        }

        public void RecoveryPassword()
        {
            //востановление пароля
            Navigation.PushAsync(new SuccessRecoveryPasswordPage());
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
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
