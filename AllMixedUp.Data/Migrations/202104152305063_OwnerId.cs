namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OwnerId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Glaze",
                c => new
                    {
                        GlazeID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        GlazeName = c.String(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                        Description = c.String(),
                        FoodSafe = c.Boolean(nullable: false),
                        FinishID = c.Int(nullable: false),
                        Atmosphere = c.Int(nullable: false),
                        MinimumCone = c.Int(nullable: false),
                        MaximumCone = c.Int(nullable: false),
                        Hue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GlazeID)
                .ForeignKey("dbo.Finish", t => t.FinishID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.FinishID);
            
            CreateTable(
                "dbo.Finish",
                c => new
                    {
                        FinishID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.FinishID);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        MaterialID = c.Int(nullable: false),
                        GlazeID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientID)
                .ForeignKey("dbo.Glaze", t => t.GlazeID, cascadeDelete: true)
                .ForeignKey("dbo.Material", t => t.MaterialID, cascadeDelete: true)
                .Index(t => t.MaterialID)
                .Index(t => t.GlazeID);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        MaterialID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        MaterialName = c.String(nullable: false),
                        HealthHazard = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.MaterialID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Glaze", "UserID", "dbo.User");
            DropForeignKey("dbo.Ingredient", "MaterialID", "dbo.Material");
            DropForeignKey("dbo.Ingredient", "GlazeID", "dbo.Glaze");
            DropForeignKey("dbo.Glaze", "FinishID", "dbo.Finish");
            DropIndex("dbo.Ingredient", new[] { "GlazeID" });
            DropIndex("dbo.Ingredient", new[] { "MaterialID" });
            DropIndex("dbo.Glaze", new[] { "FinishID" });
            DropIndex("dbo.Glaze", new[] { "UserID" });
            DropTable("dbo.Material");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Finish");
            DropTable("dbo.Glaze");
        }
    }
}
