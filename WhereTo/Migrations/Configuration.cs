namespace WhereTo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WhereTo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WhereTo.Models.PlaceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WhereTo.Models.PlaceContext context)
        {
            context.Places.AddOrUpdate(i => i.PlaceID,
                 new Place
                 {
                     ApplicationUserID = "Jane Smith",
                     PlaceID = "The Great Wall",
                     PlaceName = "The Great Wall",
                     PlaceAddress = "China",
                     PlacePic = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/50/20090529_Great_Wall_8125.jpg/1024px-20090529_Great_Wall_8125.jpg",
                     IsCompleted = true,
                     PlaceComment = "a long walk",
                     Category = "Asia",
                 },

                 new Place
                 {
                     ApplicationUserID = "Jenny Smith",
                     PlaceID = "The Great Barrier Reef",
                     PlaceName = "The Great Barrier Reef",
                     PlaceAddress = "Australia",
                     PlacePic = "http://pixabay.com/static/uploads/photo/2014/03/17/09/05/fish-288988_640.jpg",
                     IsCompleted = false,
                     PlaceComment = "beautiful",
                     Category = "Australian Adventures",
                 },

                 new Place
                 {
                     ApplicationUserID = "John Smith",
                     PlaceID = "The Leaning Tower of Pisa",
                     PlaceName = "Leaning Tower of Pisa",
                     PlacePic = "https://upload.wikimedia.org/wikipedia/commons/f/f2/Leaning_Tower_of_Pisa.jpg",
                     IsCompleted = true,
                     PlaceComment = "awful",
                     Category = "Places in France",
                 }
             );
        }
    }
}