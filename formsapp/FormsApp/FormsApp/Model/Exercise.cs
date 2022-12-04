using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FormsApp.Model
{
    //упражнение 
    //содержит название, список вопросов

    [Table("Exercise")]
    public class Exercise
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        [OneToMany]
        public List<Question> Questions { get; set; }
        public string RecomendationText  { get; set; }
        public string Image { get; set; }
    }
}