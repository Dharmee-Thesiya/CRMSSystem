namespace CRMSSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usersvalue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "MobileNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "MobileNumber", c => c.Int(nullable: false));
        }
    }
}
