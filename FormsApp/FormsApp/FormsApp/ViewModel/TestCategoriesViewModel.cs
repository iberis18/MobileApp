﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна списка категорий тестов

    internal class TestCategoriesViewModel : INotifyPropertyChanged
    {
        private readonly CategoryList allCategories = new CategoryList();
        private Category selectedCategory;


        public TestCategoriesViewModel()
        {
            BackCommand = new Command(Back);
        }

        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public List<Category> AllCategories => allCategories.GetAllTestCategories;

        //открывает список тестов в выбранной категории
        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (selectedCategory != value)
                {
                    selectedCategory = null;
                    OnPropertyChanged("SelectedCategory");
                    Navigation.PushAsync(new TestsListByCategoryPage(value.Name));
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