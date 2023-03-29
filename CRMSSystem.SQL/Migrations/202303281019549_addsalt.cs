namespace CRMSSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsalt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Passwordsalt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Passwordsalt");
        }
    }
}
