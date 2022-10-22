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
    class SuccessRecoveryPasswordViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand GoToMenuCommand { get; }
        public INavigation Navigation { get; set; }

        public SuccessRecoveryPasswordViewModel()
        {
            GoToMenuCommand = new Command(GoToMenu);
        }

        public void GoToMenu()
        {
            Navigation.PushAsync(new MainPage());
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
