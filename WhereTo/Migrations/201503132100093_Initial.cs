namespace WhereTo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(),
                        PlaceID = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        PlaceComment = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Places");
        }
    }
}
