using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FormsApp.Model
{
    //один вариант ответа на вопрос. 
    //содержит строку с текстом либо изображение, другое поле остается пустым
    [Table("Answers")]
    public class Answer
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [ForeignKey(typeof(Question))]
        public int QuestionId { get; set; }
        public bool isTrue { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
    }
}