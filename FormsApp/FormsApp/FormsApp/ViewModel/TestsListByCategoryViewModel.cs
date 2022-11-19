using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    internal class TestsListByCategoryViewModel : INotifyPropertyChanged
    {
        private readonly TestsListByCategory allTestsByCategory;
        private string categoryName;
        private string selectedTest;

        public TestsListByCategoryViewModel(string categoryName)
        {
            GoToTestCommand = new Command(GoToTest);
            BackCommand = new Command(Back);
            this.categoryName = categoryName;
            allTestsByCategory = new TestsListByCategory(categoryName);
        }

        public ICommand GoToTestCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public List<string> AllTests => allTestsByCategory.GetAllTests;

        public string Image => allTestsByCategory.GetCategory.Image;

        public string CategoryName => allTestsByCategory.GetCategory.Name;

        public event PropertyChangedEventHandler PropertyChanged;

        public void Back()
        {
            Navigation.PopAsync();
        }

        public void GoToTest()
        {
        }

        public string SelectedTest
        {
            get => selectedTest;
            set
            {
                if (selectedTest == value) return;
                var temp = value;
                selectedTest = null;
                OnPropertyChanged("SelectedTest");
                Navigation.PushAsync(new TestPage(temp));
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}