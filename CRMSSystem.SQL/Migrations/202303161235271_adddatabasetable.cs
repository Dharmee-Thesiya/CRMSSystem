namespace CRMSSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatabasetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommonLookUps",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ConfigName = c.String(),
                        ConfigKey = c.String(),
                        ConfigValue = c.String(),
                        DisplayOrder = c.Int(),
                        Description = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedOn = c.DateTime(nullable: false),
                        
                    
                    dBy = c.Guid(),
                        UpdatedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConferenceRooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                        CreatedBy = c.Guid(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(),
                        UpdatedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConferenceRooms");
            DropTable("dbo.CommonLookUps");
        }
    }
}
