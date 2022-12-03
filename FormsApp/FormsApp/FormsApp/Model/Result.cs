using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FormsApp.Model
{
    //результат пользователя
    //пройденные тесты и рекомендации
    //(с бд не будет динамики)

    [Table("Result")]
    public class Result
    {
        public Result()
        {
            //var jsonString = GetJSON();
            //var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            //GetResults = jsonObject["Results"].ToObject<List<string>>();
            //GetRecommendations = jsonObject["Recommendations"].ToObject<string>();
        }

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }


        // del
        //public List<string> GetResults { get; set; }

        //del
        //public string GetRecommendations { get; set; }


        public int Scores { get; set; }
        public string Text { get; set; }
        [ForeignKey(typeof(User))]
        public  int UserId { get; set; }
        [ForeignKey(typeof(Test))]
        public int TestId { get; set; }

        //private string GetJSON()
        //{
        //    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
        //    var json = File.Exists(path) ? File.ReadAllText(path) : "";
        //    return json;
        //}
    }
}