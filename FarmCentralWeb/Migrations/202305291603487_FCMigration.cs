namespace FarmCentralWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FCMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "FarmerId", "dbo.Farmers");
            DropIndex("dbo.Products", new[] { "FarmerId" });
            DropPrimaryKey("dbo.Farmers");
            CreateTable(
                "dbo.FarmCentralWebUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        NormalizedUserName = c.String(),
                        Email = c.String(),
                        NormalizedEmail = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        ConcurrencyStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEnd = c.DateTimeOffset(precision: 7),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Farmer_Id", c => c.Int());
            AlterColumn("dbo.Farmers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "FarmerId", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Farmers", "Id");
            CreateIndex("dbo.Products", "Farmer_Id");
            AddForeignKey("dbo.Products", "Farmer_Id", "dbo.Farmers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Farmer_Id", "dbo.Farmers");
            DropIndex("dbo.Products", new[] { "Farmer_Id" });
            DropPrimaryKey("dbo.Farmers");
            AlterColumn("dbo.Products", "FarmerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Farmers", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Products", "Farmer_Id");
            DropTable("dbo.FarmCentralWebUsers");
            AddPrimaryKey("dbo.Farmers", "Id");
            CreateIndex("dbo.Products", "FarmerId");
            AddForeignKey("dbo.Products", "FarmerId", "dbo.Farmers", "Id", cascadeDelete: true);
        }
    }
}
