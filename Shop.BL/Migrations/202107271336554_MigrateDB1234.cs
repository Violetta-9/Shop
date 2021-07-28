namespace Shop.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1234 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Foods", new[] { "Order_Id" });
            DropColumn("dbo.Foods", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Order_Id", c => c.Int());
            CreateIndex("dbo.Foods", "Order_Id");
            AddForeignKey("dbo.Foods", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
