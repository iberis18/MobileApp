using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessRecoveryPasswordPage : ContentPage
    {
        public SuccessRecoveryPasswordPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new SuccessRecoveryPasswordViewModel { Navigation = Navigation };
        }
    }
}