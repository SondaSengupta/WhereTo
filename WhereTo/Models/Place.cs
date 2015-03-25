﻿using System;
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
        public string PlaceName { get; set; }
        public string PlaceAddress { get; set; }
        public string PlacePic { get; set; }
        public bool IsCompleted { get; set; }
        public string PlaceComment { get; set; }
        public string Category { get; set; }

        public Place()
        {

        }
        
        public Place(string ApplicationUserID, string PlaceID, string PlaceName, string PlacePic,  bool IsCompleted, string PlaceComment, string Category)
        {
            this.ApplicationUserID = ApplicationUserID;
            this.PlaceID = PlaceID;
            this.PlaceName = PlaceName;
            this.PlacePic = PlacePic;
            this.IsCompleted = IsCompleted;
            this.PlaceComment = PlaceComment;
            this.Category = Category;
        }

    }


    public class PlaceContext: DbContext
    {
        public DbSet<Place> Places { get; set; }

    }


}