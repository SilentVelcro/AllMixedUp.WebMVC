namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedFinish : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Glaze", "FinishID", "dbo.Finish");
            DropIndex("dbo.Glaze", new[] { "FinishID" });
            AddColumn("dbo.Glaze", "Surface", c => c.Int(nullable: false));
            AddColumn("dbo.Glaze", "Opacity", c => c.Int(nullable: false));
            DropColumn("dbo.Glaze", "FinishID");
            DropTable("dbo.Finish");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Finish",
                c => new
                    {
                        FinishID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Surf = c.Int(nullable: false),
                        Op = c.Int(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.FinishID);
            
            AddColumn("dbo.Glaze", "FinishID", c => c.Int(nullable: false));
            DropColumn("dbo.Glaze", "Opacity");
            DropColumn("dbo.Glaze", "Surface");
            CreateIndex("dbo.Glaze", "FinishID");
            AddForeignKey("dbo.Glaze", "FinishID", "dbo.Finish", "FinishID", cascadeDelete: true);
        }
    }
}
