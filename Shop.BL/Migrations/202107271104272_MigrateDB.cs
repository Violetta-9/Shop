namespace Shop.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Proteins = c.Double(nullable: false),
                        Fats = c.Double(nullable: false),
                        Carbohydrates = c.Double(nullable: false),
                        Calories = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Moment = c.DateTime(),
                        Quantity = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        FoodToOrder_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.FoodToOrder_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.FoodToOrder_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        BirdthDate = c.DateTime(nullable: false),
                        Number = c.String(),
                        Addres = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "FoodToOrder_Id", "dbo.Foods");
            DropForeignKey("dbo.Foods", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "FoodToOrder_Id" });
            DropIndex("dbo.Foods", new[] { "Order_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Foods");
        }
    }
}
