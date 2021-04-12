namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datacreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.User", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.User", "Email", c => c.String(nullable: false));
            AddColumn("dbo.User", "Country", c => c.String(nullable: false));
            AddColumn("dbo.User", "State", c => c.String(nullable: false));
            AddColumn("dbo.User", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "CreatedDate");
            DropColumn("dbo.User", "State");
            DropColumn("dbo.User", "Country");
            DropColumn("dbo.User", "Email");
            DropColumn("dbo.User", "LastName");
            DropColumn("dbo.User", "FirstName");
        }
    }
}
