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

    [Table("Result")]
    public class Result
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public int Scores { get; set; }
        public string Text { get; set; }
        [ForeignKey(typeof(User))]
        public  int UserId { get; set; }
        [ForeignKey(typeof(Test))]
        public int TestId { get; set; }
    }
}