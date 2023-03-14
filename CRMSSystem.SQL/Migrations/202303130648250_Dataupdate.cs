namespace CRMSSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dataupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            AddColumn("dbo.Roles", "Name", c => c.String());
            AddColumn("dbo.Roles", "Code", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Roles", "UpdatedBy", c => c.Guid());
            AlterColumn("dbo.Roles", "UpdatedOn", c => c.DateTime());
            AlterColumn("dbo.UserRoles", "UpdatedBy", c => c.Guid());
            AlterColumn("dbo.UserRoles", "UpdatedOn", c => c.DateTime());
            AlterColumn("dbo.Users", "UpdatedBy", c => c.Guid());
            AlterColumn("dbo.Users", "UpdatedOn", c => c.DateTime());
            DropColumn("dbo.Roles", "RoleName");
            DropColumn("dbo.Users", "UserName");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "City", c => c.String());
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "UserName", c => c.String());
            AddColumn("dbo.Roles", "RoleName", c => c.String());
            AlterColumn("dbo.Users", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UpdatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserRoles", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserRoles", "UpdatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.Roles", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "UpdatedBy", c => c.Guid(nullable: false));
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Roles", "Code");
            DropColumn("dbo.Roles", "Name");
            CreateIndex("dbo.UserRoles", "RoleId");
            CreateIndex("dbo.UserRoles", "UserId");
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}
