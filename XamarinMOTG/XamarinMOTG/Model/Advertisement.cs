using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using XamarinMOTG.Model;
namespace XamarinMOTG.Model
{
    public class Advertisement
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(255)]

        public string Description{ get; set; }
        [MaxLength(255)]

     
        public decimal Price { get; set; }

        public bool Trade { get; set; }

    }
}
