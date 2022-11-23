using System.Collections.Generic;
using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HaveUnansweredQuestionsPage : ContentPage
    {
        public HaveUnansweredQuestionsPage(string testName, Dictionary<int, int?> answers)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new HaveUnansweredQuestionsViewModel(testName, answers) { Navigation = Navigation };
        }
    }
}