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
                     ApplicationUserID = "Jenny Smith",
                     PlaceID = "The Great Barrier Reef",
                     PlaceName = "The Great Barrier Reef",
                     PlaceAddress = "Australia",
                     PlacePic = "https://upload.wikimedia.org/wikipedia/commons/1/1b/GreatBarrierReef-EO.JPG",
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