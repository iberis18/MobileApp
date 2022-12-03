using FormsApp.Model;
using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThinkingExercisePage : ContentPage
    {
        public ThinkingExercisePage(int exId)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ThinkingExerciseViewModel(exId) { Navigation = Navigation };
        }

        public ThinkingExercisePage(Exercise ex)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ThinkingExerciseViewModel(ex) { Navigation = Navigation };
        }
    }
}