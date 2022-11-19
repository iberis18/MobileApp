using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestsListByCategoryPage : ContentPage
    {
        public TestsListByCategoryPage(string categoryName)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new TestsListByCategoryViewModel(categoryName) { Navigation = Navigation };
        }
    }
}