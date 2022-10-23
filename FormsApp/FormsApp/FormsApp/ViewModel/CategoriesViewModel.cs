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

        private CategoryList allCategories = new CategoryList();
        private Category selectedCategory = null;

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

        public List<Category> AllCategories
        {
            get { return allCategories.GetAllCategories; }
        }
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                if (selectedCategory != value)
                {
                    Category tempCategory = value;
                    selectedCategory = null;
                    OnPropertyChanged("SelectedCategory");
                    Navigation.PushAsync(new TestsListByCategoryPage(tempCategory.Name));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
