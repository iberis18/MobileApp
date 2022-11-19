using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class ExerciseCategoriesViewModel : INotifyPropertyChanged
    {
        private readonly CategoryList allCategories = new CategoryList();
        private Category selectedCategory;


        public ExerciseCategoriesViewModel()
        {
            BackCommand = new Command(Back);
        }

        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public List<Category> AllCategories => allCategories.GetAllExerciseCategories;

        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (selectedCategory != value)
                {
                    var tempCategory = value;
                    selectedCategory = null;
                    OnPropertyChanged("SelectedCategory");
                    //Navigation.PushAsync(new TestsListByCategoryPage(tempCategory.Name));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Back()
        {
            Navigation.PopAsync();
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}