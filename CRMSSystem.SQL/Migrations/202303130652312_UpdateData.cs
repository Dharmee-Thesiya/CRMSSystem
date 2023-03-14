namespace CRMSSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "CreatedBy", c => c.Guid());
            AlterColumn("dbo.Users", "CreatedBy", c => c.Guid());
            AlterColumn("dbo.UserRoles", "CreatedBy", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRoles", "CreatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "CreatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.Roles", "CreatedBy", c => c.Guid(nullable: false));
        }
    }
}
