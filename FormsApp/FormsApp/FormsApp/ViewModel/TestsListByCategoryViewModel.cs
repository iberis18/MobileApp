using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using FormsApp.Model;
using FormsApp.View;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace FormsApp.ViewModel
{
    class TestsListByCategoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string categoryName;

        TestsListByCategory allTestsByCategory;

        public ICommand GoToTestCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public TestsListByCategoryViewModel(string categoryName)
        {
            GoToTestCommand = new Command(GoToTest);
            BackCommand = new Command(Back);
            this.categoryName = categoryName;
            allTestsByCategory = new TestsListByCategory(categoryName);
        }

        public void Back()
        {
            Navigation.PopAsync();
        }

        public void GoToTest()
        {

        }

        public List<string> AllTests
        {
            get { return allTestsByCategory.GetAllTests; }
        }
        public string Image
        {
            get { return allTestsByCategory.GetCategory.Image; }
        }
        public string CategoryName
        {
            get { return allTestsByCategory.GetCategory.Name; }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
