using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна списка всех тестов выбранной категории
    internal class TestsListByCategoryViewModel : INotifyPropertyChanged
    {
        private readonly IEnumerable<Test> allTestsByCategory;
        private readonly Category category;
        private Test selectedTest;
        private readonly int userId;

        //получаем список тестов
        public TestsListByCategoryViewModel(int userId, int id)
        {
            this.userId = userId;
            BackCommand = new Command(Back);
            category = App.Database.GetCategory(id);
            allTestsByCategory = App.Database.GetTestsByCategory(id);
        }

        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        //список всех тестов в данной категории
        public List<Test> AllTests => allTestsByCategory.ToList();

        //изображение категории
        public string Image => category.Image;

        //название категории
        public string CategoryName => category.Name;

        //переход к выбранному тесту
        public Test SelectedTest
        {
            get => selectedTest;
            set
            {
                if (selectedTest == value) return;
                selectedTest = null;
                OnPropertyChanged("SelectedTest");
                Navigation.PushAsync(new TestPage(userId, value.Id));
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