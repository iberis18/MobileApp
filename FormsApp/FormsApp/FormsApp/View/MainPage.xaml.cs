using FormsApp.ViewModel;
using Xamarin.Forms;

namespace FormsApp.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel { Navigation = Navigation };
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}