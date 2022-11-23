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
    public partial class ThinkingExercisePage : ContentPage
    {
        public ThinkingExercisePage(string exName)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ThinkingExerciseViewModel(exName) { Navigation = Navigation };
        }
        public ThinkingExercisePage(Exercise ex)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ThinkingExerciseViewModel(ex) { Navigation = Navigation };
        }
    }
}