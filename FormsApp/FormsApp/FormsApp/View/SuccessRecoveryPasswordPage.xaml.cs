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
    public partial class SuccessRecoveryPasswordPage : ContentPage
    {
        public SuccessRecoveryPasswordPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new SuccessRecoveryPasswordViewModel() { Navigation = this.Navigation };
        }
    }
}