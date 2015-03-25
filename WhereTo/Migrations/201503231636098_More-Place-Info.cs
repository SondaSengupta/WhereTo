namespace WhereTo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MorePlaceInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "PlaceName", c => c.String());
            AddColumn("dbo.Places", "PlacePic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "PlacePic");
            DropColumn("dbo.Places", "PlaceName");
        }
    }
}
