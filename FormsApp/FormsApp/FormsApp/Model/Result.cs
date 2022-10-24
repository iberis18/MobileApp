using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace FormsApp.Model
{
    public class Result
    {
        private List<string> results { get; set; }
        private string recommendations { get; set; }

        public Result()
        {
            string jsonString = GetJSON();
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            results = jsonObject["Results"].ToObject<List<string>>();
            recommendations = jsonObject["Recommendations"].ToObject<string>();
        }
        private string GetJSON()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            string json = (File.Exists(path)) ? File.ReadAllText(path) : "";
            return json;
        }
        public List<string> GetResults
        {
            get { return results; }
        }
        public string GetRecommendations
        {
            get { return recommendations; }
        }
    }
}
