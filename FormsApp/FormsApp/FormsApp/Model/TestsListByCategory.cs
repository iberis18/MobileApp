using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FormsApp.Model
{
    //список тестов в одной категории
    //находит по имени категории все входящие в нее тесты
    //(с бд будет по id + с бд не будет динамики)

    public class TestsListByCategory
    {
        public TestsListByCategory(string categoryName)
        {
            var jsonString = GetJSON();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            var tests = jsonObject["Tests"];
            foreach (var x in tests)
                if (x["Category"] == categoryName)
                {
                    GetAllTests = x["Tests"].ToObject<List<string>>();
                    GetCategory = new Category { Name = x["Category"], Image = x["Image"] };
                }
        }

        public List<string> GetAllTests { get; }

        public Category GetCategory { get; }

        private string GetJSON()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            var json = File.Exists(path) ? File.ReadAllText(path) : "";
            return json;
        }
    }
}