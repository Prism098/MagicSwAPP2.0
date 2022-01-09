using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinMOTG.Model
{
    public class Set
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        [MaxLength(255)]

        public int AmountOfCards { get; set; }
    

        public DateTime ReleaseDate { get; set; }

    }
}
