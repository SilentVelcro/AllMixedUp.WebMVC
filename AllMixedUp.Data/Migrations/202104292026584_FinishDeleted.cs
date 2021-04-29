namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinishDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Glaze", "UserID", "dbo.User");
            DropIndex("dbo.Glaze", new[] { "UserID" });
            AlterColumn("dbo.Glaze", "UserID", c => c.Int());
            CreateIndex("dbo.Glaze", "UserID");
            AddForeignKey("dbo.Glaze", "UserID", "dbo.User", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Glaze", "UserID", "dbo.User");
            DropIndex("dbo.Glaze", new[] { "UserID" });
            AlterColumn("dbo.Glaze", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Glaze", "UserID");
            AddForeignKey("dbo.Glaze", "UserID", "dbo.User", "UserID", cascadeDelete: true);
        }
    }
}
