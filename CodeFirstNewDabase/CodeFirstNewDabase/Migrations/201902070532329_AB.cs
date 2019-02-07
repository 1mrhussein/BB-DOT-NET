namespace CodeFirstNewDabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AB : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Displayname", newName: "display_name");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Users", name: "display_name", newName: "Displayname");
        }
    }
}
