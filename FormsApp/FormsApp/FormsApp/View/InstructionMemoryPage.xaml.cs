using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructionMemoryPage : ContentPage
    {
        public InstructionMemoryPage(int id)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new InstructionMemoryViewModel(id) { Navigation = Navigation };
        }
    }
}