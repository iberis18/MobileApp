using System.ComponentModel;
using System.Windows.Input;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class RegistrationViewModel : INotifyPropertyChanged
    {
        private string email = "", password = "", repeatPassword = "";

        public RegistrationViewModel()
        {
            RegistrationCommand = new Command(Registration);
            BackCommand = new Command(Back);
        }

        public ICommand RegistrationCommand { get; }
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

        public string Password
        {
            get => password;
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
            get => repeatPassword;
            set
            {
                if (repeatPassword != value)
                {
                    repeatPassword = value;
                    OnPropertyChanged("RepeatPassword");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Registration()
        {
            //Добавление нового пользователя

            Navigation.PushAsync(new MainPage());
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