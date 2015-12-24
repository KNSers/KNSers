namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialNotificationHub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotiId = c.String(nullable: false, maxLength: 128),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NotiId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}
