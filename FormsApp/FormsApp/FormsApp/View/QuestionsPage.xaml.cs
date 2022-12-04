using System.Collections.Generic;
using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionsPage : ContentPage
    {
        public QuestionsPage(int userId, int testId, int currentQuestion)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new QuestionsViewModel(userId, testId, currentQuestion) { Navigation = Navigation };
        }

        public QuestionsPage(int userId, int testId, int currentQuestion, Dictionary<int, int?> answers)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new QuestionsViewModel(userId, testId, currentQuestion, answers) { Navigation = Navigation };
        }
    }
}