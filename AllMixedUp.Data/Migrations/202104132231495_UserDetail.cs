namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "ModifiedDate");
        }
    }
}
