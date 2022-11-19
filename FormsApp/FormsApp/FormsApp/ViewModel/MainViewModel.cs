using System.ComponentModel;
using System.Windows.Input;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            LoginCommand = new Command(Login);
            RegistrationCommand = new Command(Registration);
        }
        //private Phone phone;

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