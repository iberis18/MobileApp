using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FormsApp.Model
{
    //результат пользователя
    //пройденные тесты и рекомендации
    //(с бд не будет динамики)

    public class Result
    {
        public Result()
        {
            var jsonString = GetJSON();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            GetResults = jsonObject["Results"].ToObject<List<string>>();
            GetRecommendations = jsonObject["Recommendations"].ToObject<string>();
        }

        // результаты пользователя
        public List<string> GetResults { get; }

        //рекомендация для пользователя
        public string GetRecommendations { get; }

        private string GetJSON()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            var json = File.Exists(path) ? File.ReadAllText(path) : "";
            return json;
        }
    }
}