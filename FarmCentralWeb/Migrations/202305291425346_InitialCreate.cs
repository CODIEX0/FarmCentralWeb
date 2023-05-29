namespace FarmCentralWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Farmers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateSupplied = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        FarmerId = c.String(nullable: false, maxLength: 128),
                        FarmerName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Farmers", t => t.FarmerId, cascadeDelete: true)
                .Index(t => t.FarmerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "FarmerId", "dbo.Farmers");
            DropIndex("dbo.Products", new[] { "FarmerId" });
            DropTable("dbo.Products");
            DropTable("dbo.Farmers");
            DropTable("dbo.Employees");
        }
    }
}
