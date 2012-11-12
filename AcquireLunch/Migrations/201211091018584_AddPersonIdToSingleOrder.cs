namespace AcquireLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonIdToSingleOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SingleOrders", "Person_PersonId", "dbo.People");
            DropIndex("dbo.SingleOrders", new[] { "Person_PersonId" });
            AddColumn("dbo.SingleOrders", "PersonId", c => c.Int(nullable: false));
            AddForeignKey("dbo.SingleOrders", "PersonId", "dbo.People", "PersonId", cascadeDelete: true);
            CreateIndex("dbo.SingleOrders", "PersonId");
            DropColumn("dbo.SingleOrders", "Person_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SingleOrders", "Person_PersonId", c => c.Int());
            DropIndex("dbo.SingleOrders", new[] { "PersonId" });
            DropForeignKey("dbo.SingleOrders", "PersonId", "dbo.People");
            DropColumn("dbo.SingleOrders", "PersonId");
            CreateIndex("dbo.SingleOrders", "Person_PersonId");
            AddForeignKey("dbo.SingleOrders", "Person_PersonId", "dbo.People", "PersonId");
        }
    }
}
