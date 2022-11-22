using System.ComponentModel;
using System.Windows.Input;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна сброса пароля
    internal class RecoveryPasswordViewModel : INotifyPropertyChanged
    {
        private string email = "";

        public RecoveryPasswordViewModel()
        {
            RecoveryPasswordCommand = new Command(RecoveryPassword);
            BackCommand = new Command(Back);
        }

        public ICommand RecoveryPasswordCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RecoveryPassword()
        {
            //востановление пароля
            Navigation.PushAsync(new SuccessRecoveryPasswordPage());
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