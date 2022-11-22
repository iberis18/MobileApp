using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна списка всех тестов выбранной категории
    internal class TestsListByCategoryViewModel : INotifyPropertyChanged
    {
        private readonly TestsListByCategory allTestsByCategory;
        private string categoryName;
        private string selectedTest;

        //получаем список тестов по названию категории (с бд будет по id)
        public TestsListByCategoryViewModel(string categoryName)
        {
            BackCommand = new Command(Back);
            this.categoryName = categoryName;
            allTestsByCategory = new TestsListByCategory(categoryName);
        }

        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        //список всех тестов в данной категории
        public List<string> AllTests => allTestsByCategory.GetAllTests;

        //изображение категории
        public string Image => allTestsByCategory.GetCategory.Image;

        //название категории
        public string CategoryName => allTestsByCategory.GetCategory.Name;

        public event PropertyChangedEventHandler PropertyChanged;

        public void Back()
        {
            Navigation.PopAsync();
        }
        
        //переход к выбранному тесту
        public string SelectedTest
        {
            get => selectedTest;
            set
            {
                if (selectedTest == value) return;
                selectedTest = null;
                OnPropertyChanged("SelectedTest");
                Navigation.PushAsync(new TestPage(value));
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}