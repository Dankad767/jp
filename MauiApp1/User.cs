using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    [Table("user")]
    public class User
    {
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        [SQLite.Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        [Column("correct")]
        public  int Correct {  get; set; }

        [Column("incorrect")]

        public int Incorrect { get; set; }
        [SQLite.Ignore]
        public string UserDetails => $" Name: {Name}, Correct: {Correct}, Incorrect: {Incorrect}";

    }
}
