namespace AllMixedUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MateriaDetail : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Material", "CreatedDate");
            DropColumn("dbo.Material", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Material", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Material", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
