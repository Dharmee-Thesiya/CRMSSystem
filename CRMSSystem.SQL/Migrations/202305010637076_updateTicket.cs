namespace CRMSSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "AssignToId", c => c.Guid(nullable: false));
            DropColumn("dbo.Tickets", "AssignTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "AssignTo", c => c.Guid(nullable: false));
            DropColumn("dbo.Tickets", "AssignToId");
        }
    }
}
