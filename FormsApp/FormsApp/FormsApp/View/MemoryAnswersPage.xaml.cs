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
    public partial class MemoryAnswersPage : ContentPage
    {
        public MemoryAnswersPage(Exercise ex, int currentQuestion)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new MemoryAnswersViewModel(ex, currentQuestion) { Navigation = Navigation };
        }
    }
}