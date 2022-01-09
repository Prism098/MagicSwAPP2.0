using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinMOTG.Model
{
    public class Card
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        [MaxLength(255)]

        public string Description { get; set; }
        [MaxLength(255)]

        public string Cost { get; set; }

    }
}
