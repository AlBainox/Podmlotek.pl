namespace Podmlotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Subcategories", "ProductsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subcategories", "ProductsId", c => c.Int(nullable: false));
        }
    }
}
