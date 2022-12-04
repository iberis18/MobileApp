using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Xml.Schema;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp.ViewModel
{
    //vm окна вывода результатов и рекомендаций
    internal class ResultsViewModel : INotifyPropertyChanged
    {
        private readonly IEnumerable<Result> results;
        private readonly int userId;
        private List<UserResult> allResults = new List<UserResult>();

        public ResultsViewModel(int userId)
        {
            this.userId = userId;
            GoToExercisesCommand = new Command(GoToExercises);
            BackCommand = new Command(Back);
            results = App.Database.GetResultsByUserId(userId);
            foreach (var x in results)
            {
                allResults.Add(new UserResult(x));
            }
        }

        public ICommand GoToExercisesCommand { get; }
        public ICommand BackCommand { get; }
        public INavigation Navigation { get; set; }

        public List<UserResult> AllResults => allResults;

        public string Recommendations
        {
            get
            {
                if (results.Count() == 0)
                    return "Вы не прошли ни одного теста!";
                else
                {
                    double min = 100.0;
                    int testId = -1;
                    foreach (var result in results)
                    {
                        Test test = App.Database.GetTest(result.TestId);
                        for (int i = 0; i < test.Norms.Count; i++)
                            if (result.Scores >= test.Norms[i].Min && result.Scores < test.Norms[i].Max)
                            {
                                double pr = (i + 1) * 100 / test.Norms.Count;
                                if (pr < min)
                                {
                                    testId = test.Id;
                                    min = pr;
                                } 
                                break;
                            }
                    }


                    if (testId != -1)
                    {
                        Test worstTest = App.Database.GetTest(testId);
                        switch (worstTest.CategoryId)
                        {
                            case 1:
                                return
                                    "Ваш худший результат находится среди интеллектуальных тестов. Рекомендуем обратить внимание на упражнения для развития мышления!\nНачните тренировки в разделе \"Упражнения\"";
                            case 2:
                                return
                                    "Рекомендуем обратить внимание на тесты для тренировки памяти! Это поможет вам улучшить качество повседневной жизни!\nНачните тренировки в разделе \"Упражнения\"";
                            case 3: case 4:
                                return
                                    "Обратите внимание на тренировку внимания! Развитие внимательности повысит вашу эффективность, уменьшит количество ошибок и и улучшит концентрацию.\nНачните тренировки в разделе \"Упражнения\"";
                        }
                    }
                    else
                    {
                        return
                            "Вы показали превосходные результаты во всех тестах! Рекомендуем обратить внимание на тесты для тренировки памяти! Это поможет вам улучшить качество повседневной жизни!\nНачните тренировки в разделе \"Упражнения\"";
                    }
                    return "";
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void Back()
        {
            Navigation.PopAsync();
        }

        public void GoToExercises()
        {
            Navigation.PushAsync(new ExerciseCategoriesPage(userId));
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        

        public class UserResult
        {
            private Result result;
            public UserResult(Result result)
            {
                this.result = result;
            }

            public string Scores
            {
                get
                {
                    if (result.Scores % 100 >= 10 && result.Scores % 100 < 20)
                        return result.Scores.ToString() + " баллов";
                    else
                        switch (result.Scores % 10)
                        {
                            case 1: return result.Scores.ToString() + " балл";
                            case 2: case 3: case 4: return result.Scores.ToString() + " балла";
                            case 5: case 6: case 7: case 8: case 9: case 0: return result.Scores.ToString() + " баллов";
                        }
                    return "";
                }
            }
            public string Test => App.Database.GetTest(result.TestId).Name;
        }
    }
}