using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm Окна регистрации
    internal class RegistrationViewModel : INotifyPropertyChanged
    {
        private string email = "", password = "", repeatPassword = "", errorMessage = "";

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

        public void Registration()
        {
            //Добавление нового пользователя
            if (Password == "" || RepeatPassword == "" || Email == "")
            {
                ErrorMessage = "Заполните все поля!";
                return;
            }
            if (Password != RepeatPassword)
            {
                ErrorMessage = "Пароли не совпадают!";
                return;
            }
            else
            {
                User u = App.Database.GetUserByEmail(Email);
                if (u != null)
                {
                    ErrorMessage = "Данный email уже используется!";
                    return;
                }
                else
                {
                    App.Database.SaveUser(new User() { Email = email, Password = password });
                    Navigation.PushAsync(new MainPage());
                }
            }
            return;
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