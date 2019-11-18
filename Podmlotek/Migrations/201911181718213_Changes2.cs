namespace Podmlotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubcategoriesCategories", "Subcategories_SubcategoriesId", "dbo.Subcategories");
            DropForeignKey("dbo.SubcategoriesCategories", "Categories_CategoriesId", "dbo.Categories");
            DropIndex("dbo.SubcategoriesCategories", new[] { "Subcategories_SubcategoriesId" });
            DropIndex("dbo.SubcategoriesCategories", new[] { "Categories_CategoriesId" });
            CreateIndex("dbo.Subcategories", "CategoriesId");
            AddForeignKey("dbo.Subcategories", "CategoriesId", "dbo.Categories", "CategoriesId", cascadeDelete: true);
            DropColumn("dbo.Categories", "SubcategoriesId");
            DropTable("dbo.SubcategoriesCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubcategoriesCategories",
                c => new
                    {
                        Subcategories_SubcategoriesId = c.Int(nullable: false),
                        Categories_CategoriesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subcategories_SubcategoriesId, t.Categories_CategoriesId });
            
            AddColumn("dbo.Categories", "SubcategoriesId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Subcategories", "CategoriesId", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "CategoriesId" });
            CreateIndex("dbo.SubcategoriesCategories", "Categories_CategoriesId");
            CreateIndex("dbo.SubcategoriesCategories", "Subcategories_SubcategoriesId");
            AddForeignKey("dbo.SubcategoriesCategories", "Categories_CategoriesId", "dbo.Categories", "CategoriesId", cascadeDelete: true);
            AddForeignKey("dbo.SubcategoriesCategories", "Subcategories_SubcategoriesId", "dbo.Subcategories", "SubcategoriesId", cascadeDelete: true);
        }
    }
}
