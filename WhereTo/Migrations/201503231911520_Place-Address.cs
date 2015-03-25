namespace WhereTo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlaceAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "PlaceAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "PlaceAddress");
        }
    }
}
