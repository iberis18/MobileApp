﻿using FormsApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructionMemoryPage : ContentPage
    {
        public InstructionMemoryPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new InstructionMemoryViewModel { Navigation = Navigation };
        }
    }
}