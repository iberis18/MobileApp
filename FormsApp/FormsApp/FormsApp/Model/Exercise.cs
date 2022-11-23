using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FormsApp.Model
{
    //упражнение 
    //содержит название, список вопросов
    //находит конкретное упражнение по названию
    //(с бд будет по id + с бд не будет динамики)
    public class Exercise
    {
        public Exercise(string name)
        {
            var jsonString = GetJson();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            if (jsonObject == null) return;
            var test = jsonObject["Exercise"];
            if (test == null) return;
            if (name == test["Name"].ToString())
            {
                Name = test["Name"].ToString();
                Questions = test?["Questions"].ToObject<List<Question>>();
                RightAnswer = test?["RightAnswer"].ToObject<List<int>>();
            }
            else
            {
                test = jsonObject["MemoryExercise"];
                if (test == null) return;
                if (name == test["Name"].ToString())
                {
                    Name = test["Name"].ToString();
                    Questions = test?["Questions"].ToObject<List<Question>>();
                    RightAnswer = test?["RightAnswer"].ToObject<List<int>>();
                    MainImage = test?["MainImage"].ToObject<List<string>>();
                }
            }
        }

        public string Name { get; }
        public List<Question> Questions { get; }
        public List<int> RightAnswer { get; }
        public List<string> MainImage { get; }

        private static string GetJson()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            var json = File.Exists(path) ? File.ReadAllText(path) : "";
            return json;
        }
    }
}