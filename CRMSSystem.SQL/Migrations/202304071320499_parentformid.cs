namespace CRMSSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parentformid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Forms", "ParentFormID", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Forms", "ParentFormID", c => c.Guid(nullable: false));
        }
    }
}
