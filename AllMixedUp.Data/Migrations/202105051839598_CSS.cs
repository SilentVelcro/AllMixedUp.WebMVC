namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CSS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Message", "UserID", "dbo.User");
            DropIndex("dbo.Message", new[] { "UserID" });
            DropTable("dbo.Message");
        }
        
        public override void Down()
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
                    })
                .PrimaryKey(t => t.MessageID);
            
            CreateIndex("dbo.Message", "UserID");
            AddForeignKey("dbo.Message", "UserID", "dbo.User", "UserID", cascadeDelete: true);
        }
    }
}
