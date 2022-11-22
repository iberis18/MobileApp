using System.ComponentModel;
using System.Windows.Input;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна помощи (о программе)
    internal class HelpViewModel : INotifyPropertyChanged
    {
        public HelpViewModel()
        {
            GoToMenuCommand = new Command(GoToMenu);
            BackCommand = new Command(Back);
        }

        public ICommand GoToMenuCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

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