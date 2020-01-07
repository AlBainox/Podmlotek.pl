namespace Podmlotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class normal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoriesId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoriesId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Products", "CategoriesId");
            AddForeignKey("dbo.Products", "CategoriesId", "dbo.Categories", "CategoriesId", cascadeDelete: true);
        }
    }
}
