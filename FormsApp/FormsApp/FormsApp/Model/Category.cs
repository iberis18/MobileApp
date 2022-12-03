using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FormsApp.Model
{
    //категория теста и упражнения
    //содержит имя категории и изображение 
    [Table("Category")]
    public class Category
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        [OneToMany]
        public List<Test> Tests { get; set; }
    }
}