namespace Shop.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1234567 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "FoodToOrder_Id", "dbo.Foods");
            DropIndex("dbo.Orders", new[] { "FoodToOrder_Id" });
            AddColumn("dbo.Orders", "FoodToOrder", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "FoodToOrder_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "FoodToOrder_Id", c => c.Int());
            DropColumn("dbo.Orders", "FoodToOrder");
            CreateIndex("dbo.Orders", "FoodToOrder_Id");
            AddForeignKey("dbo.Orders", "FoodToOrder_Id", "dbo.Foods", "Id");
        }
    }
}
