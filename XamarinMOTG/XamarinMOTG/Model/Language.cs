using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinMOTG.Model
{
    public class Language
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

    }
}
