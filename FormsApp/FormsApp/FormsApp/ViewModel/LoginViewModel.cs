using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна входа
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private string email = "", password = "", errorMessage = "";

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            RecoveryPasswordCommand = new Command(RecoveryPassword);
            BackCommand = new Command(Back);
        }

        public ICommand LoginCommand { get; }
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
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //вход
        public void Login()
        {
            User user = App.Database.GetUserByEmailAndPassword(email, password);
            if (user != null)
            {
                ErrorMessage = "";
                Navigation.PushAsync(new MenuPage(user.Id));
            }
            else
            {
                ErrorMessage = "Неверное имя пользователя или пароль! Попробуйте еще раз!";
            }
        }

        //восстановление пароля
        public void RecoveryPassword()
        {
            Navigation.PushAsync(new RecoveryPasswordPage());
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