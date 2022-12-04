using FormsApp.Model;
using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemoryAnswersPage : ContentPage
    {
        public MemoryAnswersPage(int userId, Exercise ex, int currentQuestion)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new MemoryAnswersViewModel(userId, ex, currentQuestion) { Navigation = Navigation };
        }
    }
}