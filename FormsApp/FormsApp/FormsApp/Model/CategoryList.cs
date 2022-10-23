using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;


namespace FormsApp.Model
{
    public class CategoryList
    {
        private List<Category> allCategories = new List<Category>();
        public  CategoryList()
        {
            string jsonString = GetJSON();
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            allCategories = jsonObject["Categories"].ToObject<List<Category>>();
        }
        public string GetJSON()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            string json = (File.Exists(path)) ? File.ReadAllText(path) : "";
            return json;
        }
        public List<Category> GetAllCategories
        {
            get { return allCategories; }
        }

    }
}
