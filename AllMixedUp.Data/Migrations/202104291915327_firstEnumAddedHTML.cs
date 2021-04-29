namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstEnumAddedHTML : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Glaze", "MainColor", c => c.Int(nullable: false));
            DropColumn("dbo.Glaze", "Hue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Glaze", "Hue", c => c.Int(nullable: false));
            DropColumn("dbo.Glaze", "MainColor");
        }
    }
}
