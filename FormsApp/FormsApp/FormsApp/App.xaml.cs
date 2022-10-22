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

            //string s = "{\"Categories\":[{\"Name\":\"Интеллектуальные\",\"Image\":\"intellect.png\"},{\"Name\":\"Психологичсекие\",\"Image\":\"psycho.png\"},{\"Name\":\"Профессиональные\",\"Image\":\"work.png\"},{\"Name\":\"Личностные\",\"Image\":\"person.png\"}]}";
            //SaveJSON(s);
            //s = GetJSON();


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
