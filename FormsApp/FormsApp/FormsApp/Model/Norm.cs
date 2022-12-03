using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FormsApp.Model
{
    [Table("Norm")]
    public class Norm
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public int Min { get; set; }
        public int Max { get; set; }
        public string Text { get; set; }

        [ForeignKey(typeof(Test))]
        public int TestId { get; set; }
    }
}