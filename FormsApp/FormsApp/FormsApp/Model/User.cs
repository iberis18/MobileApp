using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FormsApp.Model
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        [OneToMany]
        public List<Result> Results { get; set; }
    }
}