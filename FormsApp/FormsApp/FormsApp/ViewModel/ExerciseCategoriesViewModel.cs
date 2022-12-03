using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна списка всех упражнений
    internal class ExerciseCategoriesViewModel : INotifyPropertyChanged
    {
        //private readonly CategoryList allCategories = new CategoryList();
        private Exercise selectedExercise;
        private IEnumerable<Exercise> allCategories = App.Database.GetExercises();

        public ExerciseCategoriesViewModel()
        {
            BackCommand = new Command(Back);
        }

        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public List<Exercise> AllCategories => allCategories.ToList();

        public Exercise SelectedCategory
        {
            get => selectedExercise;
            set
            {
                if (selectedExercise != value)
                {
                    selectedExercise = null;
                    OnPropertyChanged("SelectedCategory");
                    switch (value.Id)
                    {
                        case 1: Navigation.PushAsync(new AttentionExercisePage()); break;
                        case 2: Navigation.PushAsync(new ThinkingExercisePage(value.Id)); break;
                        case 3: Navigation.PushAsync(new InstructionMemoryPage(value.Id)); break;
                    }

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Back()
        {
            Navigation.PushAsync(new MenuPage());
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}