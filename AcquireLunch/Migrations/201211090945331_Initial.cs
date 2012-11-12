namespace AcquireLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        MenuItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuItemId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.RestaurantLocations",
                c => new
                    {
                        RestaurantLocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Address = c.String(),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantLocationId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RestaurantLocations", new[] { "RestaurantId" });
            DropIndex("dbo.MenuItems", new[] { "RestaurantId" });
            DropForeignKey("dbo.RestaurantLocations", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.MenuItems", "RestaurantId", "dbo.Restaurants");
            DropTable("dbo.RestaurantLocations");
            DropTable("dbo.MenuItems");
            DropTable("dbo.Restaurants");
        }
    }
}
