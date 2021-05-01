namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredient", "GlazeID", "dbo.Glaze");
            DropIndex("dbo.Ingredient", new[] { "GlazeID" });
            RenameColumn(table: "dbo.Ingredient", name: "GlazeID", newName: "Glaze_GlazeID");
            AlterColumn("dbo.Ingredient", "Glaze_GlazeID", c => c.Int());
            CreateIndex("dbo.Ingredient", "Glaze_GlazeID");
            AddForeignKey("dbo.Ingredient", "Glaze_GlazeID", "dbo.Glaze", "GlazeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredient", "Glaze_GlazeID", "dbo.Glaze");
            DropIndex("dbo.Ingredient", new[] { "Glaze_GlazeID" });
            AlterColumn("dbo.Ingredient", "Glaze_GlazeID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Ingredient", name: "Glaze_GlazeID", newName: "GlazeID");
            CreateIndex("dbo.Ingredient", "GlazeID");
            AddForeignKey("dbo.Ingredient", "GlazeID", "dbo.Glaze", "GlazeID", cascadeDelete: true);
        }
    }
}
