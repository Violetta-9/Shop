namespace Shop.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB123456 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "User", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "User");
        }
    }
}
