namespace Shop.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB12345 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "Order_Id", c => c.Int());
            CreateIndex("dbo.Foods", "Order_Id");
            AddForeignKey("dbo.Foods", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Foods", new[] { "Order_Id" });
            DropColumn("dbo.Foods", "Order_Id");
        }
    }
}
