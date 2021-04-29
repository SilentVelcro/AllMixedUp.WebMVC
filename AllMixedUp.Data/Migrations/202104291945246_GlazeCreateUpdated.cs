namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GlazeCreateUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Glaze", "MinCone", c => c.Int(nullable: false));
            AddColumn("dbo.Glaze", "MaxCone", c => c.Int(nullable: false));
            DropColumn("dbo.Glaze", "MinimumCone");
            DropColumn("dbo.Glaze", "MaximumCone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Glaze", "MaximumCone", c => c.Int(nullable: false));
            AddColumn("dbo.Glaze", "MinimumCone", c => c.Int(nullable: false));
            DropColumn("dbo.Glaze", "MaxCone");
            DropColumn("dbo.Glaze", "MinCone");
        }
    }
}
