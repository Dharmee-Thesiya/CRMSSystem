namespace CRMSSystem.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConferenceRoomRemove : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ConferenceRooms");
        }
        
        public override void Down()
        {
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
    }
}
