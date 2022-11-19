using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new HelpViewModel { Navigation = Navigation };
        }
    }
}