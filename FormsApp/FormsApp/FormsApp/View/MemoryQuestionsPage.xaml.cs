using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemoryQuestionsPage : ContentPage
    {
        public MemoryQuestionsPage(int userId, int exId)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new MemoryQuestionsViewModel(userId, exId) { Navigation = Navigation };
        }
    }
}