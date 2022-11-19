using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseCategoriesPage : ContentPage
    {
        public ExerciseCategoriesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ExerciseCategoriesViewModel { Navigation = Navigation };
        }
    }
}