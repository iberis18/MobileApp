using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FormsApp.Model
{
    //тест 
    //содержит название, изображение, список вопросов, краткую инструкцию прохождения и полную инструкцию-помощь
    //находит конкретный тест по названию (с бд будет по id)
    //(с бд будет по id + с бд не будет динамики)
    public class Test
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Question> Questions { get; set; }
        public string Instruction { get; set; }
        public string Help { get; set; }

        public Test(string name)
        {
            var jsonString = GetJson();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            if (jsonObject == null) return;
            var test = jsonObject["Test"];
            if (name == test["Name"].ToString())
            {
                Name = test["Name"].ToString();
                Image = test["Image"].ToString();
                Help = test["Help"].ToString();
                Instruction = test["Instruction"].ToString();
                Questions = test?["Questions"].ToObject<List<Question>>();
            }
        }

        private static string GetJson()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            var json = File.Exists(path) ? File.ReadAllText(path) : "";
            return json;
        }
    }
}