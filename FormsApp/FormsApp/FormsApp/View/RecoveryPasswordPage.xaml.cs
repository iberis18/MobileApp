using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecoveryPasswordPage : ContentPage
    {
        public RecoveryPasswordPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new RecoveryPasswordViewModel { Navigation = Navigation };
        }
    }
}