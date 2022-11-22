using System.ComponentModel;
using System.Windows.Input;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна успешного сброса пароля
    internal class SuccessRecoveryPasswordViewModel : INotifyPropertyChanged
    {
        public SuccessRecoveryPasswordViewModel()
        {
            GoToMenuCommand = new Command(GoToMenu);
        }

        public ICommand GoToMenuCommand { get; }
        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

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