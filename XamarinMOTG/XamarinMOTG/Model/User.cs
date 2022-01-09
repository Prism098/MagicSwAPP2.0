using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinMOTG.Model
{
    [Table("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [MaxLength(255)]
        [Column("name")]
        public string  Name { get; set; }

        [MaxLength(255)]
        [Column("username")]
        public string Username { get; set; }

        [MaxLength(320), Unique]
        [Column("email")]
        public string Email { get; set; }

        [MaxLength(255)]
        [Column("password")]
        public string Password { get; set; }

    }
}
