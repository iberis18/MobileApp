using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpTestPage : ContentPage
    {
        public HelpTestPage(string testName)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new HelpTestViewModel(testName) { Navigation = Navigation };
        }
    }
}