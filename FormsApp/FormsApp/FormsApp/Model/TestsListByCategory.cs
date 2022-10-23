using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace FormsApp.Model
{
    public class TestsListByCategory
    {
        private List<string> tests;
        private Category category;

        public TestsListByCategory(string categoryName)
        {
            string jsonString = GetJSON();
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            var tests = jsonObject["Tests"];
            foreach (var x in tests)
                if (x["Category"] == categoryName)
                {
                    this.tests = x["Tests"].ToObject<List<string>>();
                    category = new Category() { Name = x["Category"], Image = x["Image"] };
                }
        }
        private string GetJSON()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            string json = (File.Exists(path)) ? File.ReadAllText(path) : "";
            return json;
        }
        public List<string> GetAllTests
        {
            get { return tests; }
        }
        public Category GetCategory
        {
            get { return category; }
        }
    }
}
