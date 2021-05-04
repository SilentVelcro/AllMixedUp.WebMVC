namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GlazeObDel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ingredient", "MaterialName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredient", "MaterialName", c => c.String());
        }
    }
}
