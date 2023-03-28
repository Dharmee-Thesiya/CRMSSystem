namespace CRMSSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String());
            AddColumn("dbo.Users", "MobileNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "MobileNumber");
            DropColumn("dbo.Users", "UserName");
        }
    }
}
