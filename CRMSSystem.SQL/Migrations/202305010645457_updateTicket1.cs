namespace CRMSSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTicket1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "AssignId", c => c.Guid(nullable: false));
            DropColumn("dbo.Tickets", "AssignToId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "AssignToId", c => c.Guid(nullable: false));
            DropColumn("dbo.Tickets", "AssignId");
        }
    }
}
