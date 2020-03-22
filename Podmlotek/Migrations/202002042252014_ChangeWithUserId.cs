namespace Podmlotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWithUserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "UsersId", "dbo.Users");
            DropIndex("dbo.Products", new[] { "UsersId" });
            AddColumn("dbo.Products", "AspNetUsersId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "UserId", c => c.String());
            DropColumn("dbo.Products", "UsersId");
            DropColumn("dbo.Orders", "UsersId");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UsersId = c.Int(nullable: false, identity: true),
                        role = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 30),
                        ConfirmPassword = c.String(),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.UsersId);
            
            AddColumn("dbo.Orders", "UsersId", c => c.String());
            AddColumn("dbo.Products", "UsersId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "UserId");
            DropColumn("dbo.Products", "AspNetUsersId");
            CreateIndex("dbo.Products", "UsersId");
            AddForeignKey("dbo.Products", "UsersId", "dbo.Users", "UsersId", cascadeDelete: true);
        }
    }
}
