using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinMOTG.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string  Name { get; set; }
        [MaxLength(255)]

        public string Email { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

    }
}
