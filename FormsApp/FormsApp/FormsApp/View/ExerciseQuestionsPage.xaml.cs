using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsApp.Model;
using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseQuestionsPage : ContentPage
    {
        public ExerciseQuestionsPage(string exName)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ExerciseQuestionsViewModel(exName) { Navigation = Navigation };
        }
        public ExerciseQuestionsPage(Exercise ex)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ExerciseQuestionsViewModel(ex) { Navigation = Navigation };
        }
    }
}