namespace Podmlotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoriesId = c.Int(nullable: false, identity: true),
                        SubcategoriesId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoriesId);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        SubcategoriesId = c.Int(nullable: false, identity: true),
                        CategoriesId = c.Int(nullable: false),
                        ProductsId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SubcategoriesId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductsId = c.Int(nullable: false, identity: true),
                        SubcategoriesId = c.Int(nullable: false),
                        UsersId = c.Int(nullable: false),
                        Item = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        Picture = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bestseller = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                        ShortDescription = c.String(),
                    })
                .PrimaryKey(t => t.ProductsId)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoriesId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UsersId, cascadeDelete: true)
                .Index(t => t.SubcategoriesId)
                .Index(t => t.UsersId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UsersId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.UsersId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrdersId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        OrderValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Users_UsersId = c.Int(),
                    })
                .PrimaryKey(t => t.OrdersId)
                .ForeignKey("dbo.Users", t => t.Users_UsersId)
                .Index(t => t.Users_UsersId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrdersId = c.Int(nullable: false),
                        ProductsId = c.Int(nullable: false),
                        Pieces = c.Int(nullable: false),
                        OrderPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Orders", t => t.OrdersId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductsId, cascadeDelete: true)
                .Index(t => t.OrdersId)
                .Index(t => t.ProductsId);
            
            CreateTable(
                "dbo.SubcategoriesCategories",
                c => new
                    {
                        Subcategories_SubcategoriesId = c.Int(nullable: false),
                        Categories_CategoriesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subcategories_SubcategoriesId, t.Categories_CategoriesId })
                .ForeignKey("dbo.Subcategories", t => t.Subcategories_SubcategoriesId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Categories_CategoriesId, cascadeDelete: true)
                .Index(t => t.Subcategories_SubcategoriesId)
                .Index(t => t.Categories_CategoriesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Users_UsersId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "ProductsId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrdersId", "dbo.Orders");
            DropForeignKey("dbo.Products", "UsersId", "dbo.Users");
            DropForeignKey("dbo.Products", "SubcategoriesId", "dbo.Subcategories");
            DropForeignKey("dbo.SubcategoriesCategories", "Categories_CategoriesId", "dbo.Categories");
            DropForeignKey("dbo.SubcategoriesCategories", "Subcategories_SubcategoriesId", "dbo.Subcategories");
            DropIndex("dbo.SubcategoriesCategories", new[] { "Categories_CategoriesId" });
            DropIndex("dbo.SubcategoriesCategories", new[] { "Subcategories_SubcategoriesId" });
            DropIndex("dbo.OrderItems", new[] { "ProductsId" });
            DropIndex("dbo.OrderItems", new[] { "OrdersId" });
            DropIndex("dbo.Orders", new[] { "Users_UsersId" });
            DropIndex("dbo.Products", new[] { "UsersId" });
            DropIndex("dbo.Products", new[] { "SubcategoriesId" });
            DropTable("dbo.SubcategoriesCategories");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Subcategories");
            DropTable("dbo.Categories");
        }
    }
}
