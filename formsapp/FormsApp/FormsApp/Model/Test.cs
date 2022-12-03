using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FormsApp.Model
{
    //тест 
    //содержит название, изображение, список вопросов, краткую инструкцию прохождения и полную инструкцию-помощь

    [Table("Test")]
    public class Test
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }

        [ForeignKey(typeof(Category))]
        public int CategoryId { get; set; }

        [OneToMany]
        public List<Question> Questions { get; set; }

        [OneToMany]
        public List<Norm> Norms { get; set; }
        public string Instruction { get; set; }
        public string Help { get; set; }

    }
}