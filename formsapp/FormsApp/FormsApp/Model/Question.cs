using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FormsApp.Model
{
    //вопрос из теста
    //содержит текст вопроса, и/или картинку, список возможных вариантов ответов

    [Table("Question")]
    public class Question
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [ForeignKey(typeof(Test))]
        public int? TestId { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string ExerciseImage { get; set; }

        [OneToMany]
        public List<Answer> Answers { get; set; }

        [ForeignKey(typeof(Exercise))]
        public int? ExerciseId { get; set; }
    }
}