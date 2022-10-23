using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FormsApp.View;
using System.IO;

namespace FormsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string s = "{\"Categories\":[{\"Name\":\"Интеллектуальные\",\"Image\":\"intellect.png\"},{\"Name\":\"Психологические\",\"Image\":\"psycho.png\"},{\"Name\":\"Профессиональные\",\"Image\":\"work.png\"},{\"Name\":\"Личностные\",\"Image\":\"person.png\"}],\"Tests\":[{\"Category\":\"Интеллектуальные\",\"Image\":\"intellect.png\",\"Tests\":[\"Тест АйзенканаIQ\",\"Тест IQ для детей\",\"Еще один тест\",\"Ну и еще один\",\"И этот добавим\"]},{\"Category\":\"Психологические\",\"Image\":\"psycho.png\",\"Tests\":[\"Чернильные пятна Роршарха\",\"Уровень стресса\",\"Еще один тест\",\"Ну и еще один\",\"И этот добавим\"]},{\"Category\":\"Профессиональные\",\"Image\":\"work.png\",\"Tests\":[\"Определение профориентации\",\"Склонность к профессии\",\"Еще один тест\",\"Ну и еще один\",\"И этот добавим\"]},{\"Category\":\"Личностные\",\"Image\":\"person.png\",\"Tests\":[\"Лидерские качества\",\"Тип мышления\",\"Тест на темперамент\",\"Еще один тест\",\"Ну и еще один\",\"И этот добавим\"]}]}";
            SaveJSON(s);

            NavigationPage.SetHasNavigationBar(this, false);
            MainPage = new NavigationPage(new View.MainPage());


        }
        public void SaveJSON(string jsonText)
        {
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json"), jsonText);
        }
        public string GetJSON()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            string json = (File.Exists(path)) ? File.ReadAllText(path) : "";
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
