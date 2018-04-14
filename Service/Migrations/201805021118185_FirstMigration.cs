namespace Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.OrderDishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        DishId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.DishId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DishProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        DishId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.DishId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDishes", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.RequestProducts", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.RequestProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.DishProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.DishProducts", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.OrderDishes", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropIndex("dbo.RequestProducts", new[] { "RequestId" });
            DropIndex("dbo.RequestProducts", new[] { "ProductId" });
            DropIndex("dbo.DishProducts", new[] { "ProductId" });
            DropIndex("dbo.DishProducts", new[] { "DishId" });
            DropIndex("dbo.OrderDishes", new[] { "OrderId" });
            DropIndex("dbo.OrderDishes", new[] { "DishId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropTable("dbo.Requests");
            DropTable("dbo.RequestProducts");
            DropTable("dbo.Products");
            DropTable("dbo.DishProducts");
            DropTable("dbo.Dishes");
            DropTable("dbo.OrderDishes");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
        }
    }
}
