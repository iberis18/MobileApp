using System;
using System.IO;
using FormsApp.Model;
using FormsApp.View;
using Xamarin.Forms;

namespace FormsApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "DataBase.db";
        public static Context database;
        public static Context Database
        {
            get
            {
                if (database == null)
                {
                    database = new Context(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            //var s =
                //"{\"TestCategories\":[{\"Name\":\"Интеллектуальные\",\"Image\":\"intellect.png\"},{\"Name\":\"Психологические\",\"Image\":\"psycho.png\"},{\"Name\":\"Профессиональные\",\"Image\":\"work.png\"},{\"Name\":\"Личностные\",\"Image\":\"person.png\"}],\"Tests\":[{\"Category\":\"Интеллектуальные\",\"Image\":\"intellect.png\",\"Tests\":[\"Тест Айзенка на IQ\",\"Тест IQ для детей\",\"Еще один тест\",\"Ну и еще один\",\"И этот добавим\"]},{\"Category\":\"Психологические\",\"Image\":\"psycho.png\",\"Tests\":[\"Чернильные пятна Роршарха\",\"Уровень стресса\",\"Еще один тест\",\"Ну и еще один\",\"И этот добавим\"]},{\"Category\":\"Профессиональные\",\"Image\":\"work.png\",\"Tests\":[\"Определение профориентации\",\"Склонность к профессии\",\"Еще один тест\",\"Ну и еще один\",\"И этот добавим\"]},{\"Category\":\"Личностные\",\"Image\":\"person.png\",\"Tests\":[\"Лидерские качества\",\"Тип мышления\",\"Тест на темперамент\",\"Еще один тест\",\"Ну и еще один\",\"И этот добавим\"]}],\"Results\":[\"Ваш IQ 130\",\"Коэффициент внимания 60\",\"Коэффициент памяти 150\"],\"Recommendations\":\"Обратите внимание на тренировку внимания! Развитие внимательности повысит вашу эффективность, уменьшит количество ошибок и улучшит концентрацию.\\nНачните тренировки в разделе “Упражнения”\",\"ExerciseCategories\":[{\"Name\":\"Внимательность\",\"Image\":\"attention.png\"},{\"Name\":\"Мышление\",\"Image\":\"thinking.png\"},{\"Name\":\"Память\",\"Image\":\"memory.png\"}], \"Test\":{\"Name\":\"Тест Айзенка на IQ\",\"Image\":\"intellect.png\",\"Instruction\":\"Тест Айзенка — тест коэффициента интеллекта (IQ), разработанный английским психологом Гансом Айзенком. Тест содержит 40 вопросов разной сложности, ответить на которые необходимо в течение 30 минут. Не засиживайтесь слишком долго над каким-нибудь вопросом но и не сдавайтесь слишком легко; большинство задач можно решить, имея немного терпения.  Вы можете пропустить вопрс стрелкой в правом верхнем углу экрана.\",\"Help\":\"Тест Айзенка — тест коэффициента интеллекта (IQ), разработанный английским психологом Гансом Айзенком. Известно восемь различных вариантов теста Айзенка на интеллект. Первые пять тестов довольно похожи и дают общую оценку интеллекта человека при условии, что он будет тщательно следовать инструкциям. Эти тесты иногда называются сборными тестами. Они предназначены для общей оценки интеллектуальных способностей с использованием словесного, цифрового и графического материала с различными способами формулировки задач. Таким образом, можно надеяться на взаимную нейтрализацию достоинств и недостатков; к примеру, человек, который хорошо справляется со словесными заданиями, но плохо решает арифметические задачи, не получит каких-либо преимуществ, но и не окажется в невыгодном положении, так как оба вида задач представлены в тестах примерно поровну.\",\"Questions\":[{\"Text\":\"Выберите правильную фигуру из четырех предложенных.\",\"Image\":\"t1_q1.png\",\"Answers\":[{\"Text\":\"\",\"Image\":\"t1_q1_a1.png\"},{\"Text\":\"\",\"Image\":\"t1_q1_a2.png\"},{\"Text\":\"\",\"Image\":\"t1_q1_a3.png\"},{\"Text\":\"\",\"Image\":\"t1_q1_a4.png\"}]},{\"Text\":\"Найдите лишнее слово:\",\"Image\":\"\",\"Answers\":[{\"Text\":\"ЖУКРАК\",\"Image\":\"\"},{\"Text\":\"ЖОЛАК\",\"Image\":\"\"},{\"Text\":\"ЯНАБ\",\"Image\":\"\"},{\"Text\":\"AЛTEKАР\",\"Image\":\"\"}]},{\"Text\":\"Выберите лишнее слово.\",\"Image\":\"\",\"Answers\":[{\"Text\":\"Дом\",\"Image\":\"\"},{\"Text\":\"Иглу\",\"Image\":\"\"},{\"Text\":\"Бунгало\",\"Image\":\"\"},{\"Text\":\"Офис\",\"Image\":\"\"}]},{\"Text\":\"Найдите недостающее число.\\n7 10 9 12 11 _\",\"Image\":\"\",\"Answers\":[{\"Text\":\"4\",\"Image\":\"\"},{\"Text\":\"13\",\"Image\":\"\"},{\"Text\":\"10\",\"Image\":\"\"},{\"Text\":\"14\",\"Image\":\"\"}]}]},\"Exercise\":{\"Name\":\"Мышление\",\"Questions\":[{\"Text\":\"Найдите сумму времени на часах\",\"Image\":\"e1_q1.png\",\"Answers\":[{\"Text\":\"9:00\",\"Image\":\"\"},{\"Text\":\"5:00\",\"Image\":\"\"},{\"Text\":\"7:00\",\"Image\":\"\"},{\"Text\":\"6:00\",\"Image\":\"\"}]},{\"Text\":\"Найдите сумму углов фигур\",\"Image\":\"e1_q2.png\",\"Answers\":[{\"Text\":\"9\",\"Image\":\"\"},{\"Text\":\"10\",\"Image\":\"\"},{\"Text\":\"8\",\"Image\":\"\"},{\"Text\":\"12\",\"Image\":\"\"}]}],\"RightAnswer\":[1,0]},\"MemoryExercise\":{\"Name\":\"Память\",\"Questions\":[{\"Text\":\"Сколько самолетов вы запомнили?\",\"Image\":\"\",\"Answers\":[{\"Text\":\"1\",\"Image\":\"\"},{\"Text\":\"2\",\"Image\":\"\"},{\"Text\":\"3\",\"Image\":\"\"},{\"Text\":\"4\",\"Image\":\"\"}]},{\"Text\":\"Сколько самолетов, которые смотрят в заданном направлении вы запомнили?\",\"Image\":\"e2_q2_2.png\",\"Answers\":[{\"Text\":\"1\",\"Image\":\"\"},{\"Text\":\"2\",\"Image\":\"\"},{\"Text\":\"3\",\"Image\":\"\"},{\"Text\":\"4\",\"Image\":\"\"}]}],\"RightAnswer\":[2,2],\"MainImage\":[\"e2_q1_1.png\",\"e2_q2_1.png\"]}}";
            //SaveJson(s);

            NavigationPage.SetHasNavigationBar(this, false);
            MainPage = new NavigationPage(new MainPage());
        }

        public void SaveJson(string jsonText)
        {
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json"),
                jsonText);
        }

        public string GetJson()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            var json = File.Exists(path) ? File.ReadAllText(path) : "";
            return json;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}