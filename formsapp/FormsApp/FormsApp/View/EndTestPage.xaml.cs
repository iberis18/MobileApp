using System.Collections.Generic;
using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndTestPage : ContentPage
    {
        public EndTestPage(int testId, Dictionary<int, int?> answers)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new EndTestViewModel(testId, answers) { Navigation = Navigation };
        }
    }
}