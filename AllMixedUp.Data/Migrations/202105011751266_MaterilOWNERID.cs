namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaterilOWNERID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Material", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Material", "OwnerId", c => c.Guid(nullable: false));
        }
    }
}
