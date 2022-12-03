using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreparingForTestPage : ContentPage
    {
        public PreparingForTestPage(int testId)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new PreparingForTestViewModel(testId) { Navigation = Navigation };
        }
    }
}