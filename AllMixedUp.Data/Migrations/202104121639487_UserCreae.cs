namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCreae : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "OwnerID");
        }
    }
}
