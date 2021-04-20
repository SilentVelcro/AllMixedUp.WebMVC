namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        UserID = c.Int(nullable: false),
                        Body = c.String(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                        Glaze_GlazeID = c.Int(),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Glaze", t => t.Glaze_GlazeID)
                .Index(t => t.UserID)
                .Index(t => t.Glaze_GlazeID);
            
            AddColumn("dbo.Ingredient", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Ingredient", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Ingredient", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Message", "Glaze_GlazeID", "dbo.Glaze");
            DropForeignKey("dbo.Message", "UserID", "dbo.User");
            DropIndex("dbo.Message", new[] { "Glaze_GlazeID" });
            DropIndex("dbo.Message", new[] { "UserID" });
            DropColumn("dbo.Ingredient", "ModifiedDate");
            DropColumn("dbo.Ingredient", "CreatedDate");
            DropColumn("dbo.Ingredient", "OwnerId");
            DropTable("dbo.Message");
        }
    }
}
