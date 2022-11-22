using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FormsApp.Model
{
    //список всех категорий тестов или упражнений
    //получает данные из хранилища
    //(с бд не будет динамики)

    public class CategoryList
    {
        public CategoryList()
        {
            var jsonString = GetJSON();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            GetAllTestCategories = jsonObject["TestCategories"].ToObject<List<Category>>();
            GetAllExerciseCategories = jsonObject["ExerciseCategories"].ToObject<List<Category>>();
        }

        //возвращает список всех категорий тестов
        public List<Category> GetAllTestCategories { get; } = new List<Category>();

        //возвращает список всех категорий упражнений
        public List<Category> GetAllExerciseCategories { get; } = new List<Category>();

        public string GetJSON()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            var json = File.Exists(path) ? File.ReadAllText(path) : "";
            return json;
        }
    }
}