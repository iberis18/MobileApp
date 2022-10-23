using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FormsApp.ViewModel;

namespace FormsApp.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel() { Navigation = this.Navigation };
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
