using System.Collections.Generic;
using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HaveUnansweredQuestionsPage : ContentPage
    {
        public HaveUnansweredQuestionsPage(int userId, int testId, Dictionary<int, int?> answers)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new HaveUnansweredQuestionsViewModel(userId, testId, answers) { Navigation = Navigation };
        }
    }
}