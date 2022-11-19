using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new RegistrationViewModel { Navigation = Navigation };
        }
    }
}