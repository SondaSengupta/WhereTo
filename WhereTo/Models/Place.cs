using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WhereTo.Models
{
    public class Place
    {
        public int ID { get; set; }
        public string ApplicationUserID { get; set; }
        public string PlaceID { get; set; }
        public bool IsCompleted { get; set; }
        public string PlaceComment { get; set; }
        public string Category { get; set; }
    }
}