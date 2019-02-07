namespace GeneralStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            DropColumn("dbo.Customers", "CutomerID");
            AddColumn("dbo.Customers", "CustomerID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CutomerID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Customers");
            DropColumn("dbo.Customers", "CustomerID");
            AddPrimaryKey("dbo.Customers", "CutomerID");
        }
    }
}
