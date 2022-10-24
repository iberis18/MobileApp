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
    class HelpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand GoToMenuCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public HelpViewModel()
        {
            GoToMenuCommand = new Command(GoToMenu);
            BackCommand = new Command(Back);
        }

        public void GoToMenu()
        {
            Navigation.PushAsync(new MenuPage());
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
