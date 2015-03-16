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

        public Place()
        {

        }
        
        public Place(string ApplicationUserID, string PlaceID, bool IsCompleted, string PlaceComment, string Category)
        {
            this.ApplicationUserID = ApplicationUserID;
            this.PlaceID = PlaceID;
            this.IsCompleted = IsCompleted;
            this.PlaceComment = PlaceComment;
            this.Category = Category;
        }

    }


    public class PlaceContext: DbContext
    {
        public PlaceContext()
        {

        }

        public PlaceContext(string connection="DefaultConnection") : base(connection)
        {

        }

        public DbSet<Place> Places { get; set; }

    }


}