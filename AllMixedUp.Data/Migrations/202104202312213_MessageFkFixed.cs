namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageFkFixed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Message", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
        }
    }
}
