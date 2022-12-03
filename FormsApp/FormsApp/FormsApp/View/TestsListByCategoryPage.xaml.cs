using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestsListByCategoryPage : ContentPage
    {
        public TestsListByCategoryPage(int categoryId)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new TestsListByCategoryViewModel(categoryId) { Navigation = Navigation };
        }
    }
}