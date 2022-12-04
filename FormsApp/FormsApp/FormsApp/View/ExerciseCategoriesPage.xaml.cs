using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseCategoriesPage : ContentPage
    {
        public ExerciseCategoriesPage(int userId)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ExerciseCategoriesViewModel(userId) { Navigation = Navigation };
        }
    }
}