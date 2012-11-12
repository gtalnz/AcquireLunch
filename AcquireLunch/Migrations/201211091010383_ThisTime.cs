namespace AcquireLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThisTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        IsInternal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.SingleOrders",
                c => new
                    {
                        SingleOrderId = c.Int(nullable: false, identity: true),
                        Notes = c.String(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.SingleOrderId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            AddColumn("dbo.MenuItems", "SingleOrder_SingleOrderId", c => c.Int());
            AddForeignKey("dbo.MenuItems", "SingleOrder_SingleOrderId", "dbo.SingleOrders", "SingleOrderId");
            CreateIndex("dbo.MenuItems", "SingleOrder_SingleOrderId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SingleOrders", new[] { "Person_PersonId" });
            DropIndex("dbo.MenuItems", new[] { "SingleOrder_SingleOrderId" });
            DropForeignKey("dbo.SingleOrders", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.MenuItems", "SingleOrder_SingleOrderId", "dbo.SingleOrders");
            DropColumn("dbo.MenuItems", "SingleOrder_SingleOrderId");
            DropTable("dbo.SingleOrders");
            DropTable("dbo.People");
        }
    }
}
