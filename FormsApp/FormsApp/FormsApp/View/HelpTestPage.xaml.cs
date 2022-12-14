using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpTestPage : ContentPage
    {
        public HelpTestPage(int userId, int testId)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new HelpTestViewModel(userId, testId) { Navigation = Navigation };
        }
    }
}