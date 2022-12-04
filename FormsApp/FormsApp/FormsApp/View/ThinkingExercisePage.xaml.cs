using FormsApp.Model;
using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThinkingExercisePage : ContentPage
    {
        public ThinkingExercisePage(int userId, int exId)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ThinkingExerciseViewModel(userId, exId) { Navigation = Navigation };
        }

        public ThinkingExercisePage(int userId, Exercise ex)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ThinkingExerciseViewModel(userId, ex) { Navigation = Navigation };
        }
    }
}