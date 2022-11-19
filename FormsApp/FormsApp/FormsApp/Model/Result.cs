using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FormsApp.Model
{
    public class Result
    {
        public Result()
        {
            var jsonString = GetJSON();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            results = jsonObject["Results"].ToObject<List<string>>();
            recommendations = jsonObject["Recommendations"].ToObject<string>();
        }

        private List<string> results { get; }
        private string recommendations { get; }

        public List<string> GetResults => results;

        public string GetRecommendations => recommendations;

        private string GetJSON()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            var json = File.Exists(path) ? File.ReadAllText(path) : "";
            return json;
        }
    }
}