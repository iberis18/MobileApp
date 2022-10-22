using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using FormsApp.Model;
using FormsApp.View;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    class CategoriesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        CategoryList allCategories = new CategoryList();

        public ICommand GoToCategoryCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }


        public CategoriesViewModel()
        {
            GoToCategoryCommand = new Command(GoToCategory);
            BackCommand = new Command(Back);
        }

        public void Back()
        {
            Navigation.PopAsync();
        }

        public void GoToCategory()
        {

        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
