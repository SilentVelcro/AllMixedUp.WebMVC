namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinishCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Finish", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Finish", "Surf", c => c.Int(nullable: false));
            AddColumn("dbo.Finish", "Op", c => c.Int(nullable: false));
            AddColumn("dbo.Finish", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Finish", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Finish", "ModifiedDate");
            DropColumn("dbo.Finish", "CreatedDate");
            DropColumn("dbo.Finish", "Op");
            DropColumn("dbo.Finish", "Surf");
            DropColumn("dbo.Finish", "OwnerId");
        }
    }
}
