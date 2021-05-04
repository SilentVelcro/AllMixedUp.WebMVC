namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SelectListTry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredient", "MaterialName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingredient", "MaterialName");
        }
    }
}
