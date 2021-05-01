namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class glszed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Material", "Ingredient_IngredientID", "dbo.Ingredient");
            DropForeignKey("dbo.Ingredient", "Glaze_GlazeID", "dbo.Glaze");
            DropIndex("dbo.Ingredient", new[] { "Glaze_GlazeID" });
            DropIndex("dbo.Material", new[] { "Ingredient_IngredientID" });
            RenameColumn(table: "dbo.Ingredient", name: "Glaze_GlazeID", newName: "GlazeID");
            AlterColumn("dbo.Ingredient", "GlazeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Ingredient", "GlazeID");
            AddForeignKey("dbo.Ingredient", "GlazeID", "dbo.Glaze", "GlazeID", cascadeDelete: true);
            DropColumn("dbo.Material", "Ingredient_IngredientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Material", "Ingredient_IngredientID", c => c.Int());
            DropForeignKey("dbo.Ingredient", "GlazeID", "dbo.Glaze");
            DropIndex("dbo.Ingredient", new[] { "GlazeID" });
            AlterColumn("dbo.Ingredient", "GlazeID", c => c.Int());
            RenameColumn(table: "dbo.Ingredient", name: "GlazeID", newName: "Glaze_GlazeID");
            CreateIndex("dbo.Material", "Ingredient_IngredientID");
            CreateIndex("dbo.Ingredient", "Glaze_GlazeID");
            AddForeignKey("dbo.Ingredient", "Glaze_GlazeID", "dbo.Glaze", "GlazeID");
            AddForeignKey("dbo.Material", "Ingredient_IngredientID", "dbo.Ingredient", "IngredientID");
        }
    }
}
