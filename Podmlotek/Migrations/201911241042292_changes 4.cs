namespace Podmlotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ShortDescription", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ShortDescription", c => c.String());
        }
    }
}
