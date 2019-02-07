namespace CodeFirstNewDabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class B : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Displayname = c.String(),
                    })
                .PrimaryKey(t => t.Username);
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
