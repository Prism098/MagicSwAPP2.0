using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinMOTG.Model
{
    public class Bid
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Amount { get; set; }

    }
}
