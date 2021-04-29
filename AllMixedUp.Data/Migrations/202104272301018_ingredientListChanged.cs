namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ingredientListChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Message", "Glaze_GlazeID", "dbo.Glaze");
            DropIndex("dbo.Message", new[] { "Glaze_GlazeID" });
            AddColumn("dbo.Material", "Ingredient_IngredientID", c => c.Int());
            CreateIndex("dbo.Material", "Ingredient_IngredientID");
            AddForeignKey("dbo.Material", "Ingredient_IngredientID", "dbo.Ingredient", "IngredientID");
            DropColumn("dbo.Message", "Glaze_GlazeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "Glaze_GlazeID", c => c.Int());
            DropForeignKey("dbo.Material", "Ingredient_IngredientID", "dbo.Ingredient");
            DropIndex("dbo.Material", new[] { "Ingredient_IngredientID" });
            DropColumn("dbo.Material", "Ingredient_IngredientID");
            CreateIndex("dbo.Message", "Glaze_GlazeID");
            AddForeignKey("dbo.Message", "Glaze_GlazeID", "dbo.Glaze", "GlazeID");
        }
    }
}
