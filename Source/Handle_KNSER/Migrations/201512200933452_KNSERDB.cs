namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KNSERDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        OtherId = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Score = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Leader_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Members", t => t.Leader_MemberId)
                .Index(t => t.Leader_MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        KNSId = c.Int(nullable: false),
                        Fullname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        University = c.String(),
                        Year = c.Int(nullable: false),
                        Description = c.String(),
                        Term = c.Int(nullable: false),
                        KNSRole = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Letters",
                c => new
                    {
                        LetterId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.LetterId);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ParticipantId = c.Int(nullable: false, identity: true),
                        PartDate = c.DateTime(nullable: false),
                        EventRole = c.String(),
                        Event_EventId = c.Int(),
                        Member_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.ParticipantId)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .ForeignKey("dbo.Members", t => t.Member_MemberId)
                .Index(t => t.Event_EventId)
                .Index(t => t.Member_MemberId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        LetterId_LetterId = c.Int(),
                        MemberId_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Letters", t => t.LetterId_LetterId)
                .ForeignKey("dbo.Members", t => t.MemberId_MemberId)
                .Index(t => t.LetterId_LetterId)
                .Index(t => t.MemberId_MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "MemberId_MemberId", "dbo.Members");
            DropForeignKey("dbo.Requests", "LetterId_LetterId", "dbo.Letters");
            DropForeignKey("dbo.Participants", "Member_MemberId", "dbo.Members");
            DropForeignKey("dbo.Participants", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "Leader_MemberId", "dbo.Members");
            DropIndex("dbo.Requests", new[] { "MemberId_MemberId" });
            DropIndex("dbo.Requests", new[] { "LetterId_LetterId" });
            DropIndex("dbo.Participants", new[] { "Member_MemberId" });
            DropIndex("dbo.Participants", new[] { "Event_EventId" });
            DropIndex("dbo.Events", new[] { "Leader_MemberId" });
            DropTable("dbo.Requests");
            DropTable("dbo.Participants");
            DropTable("dbo.Letters");
            DropTable("dbo.Members");
            DropTable("dbo.Events");
        }
    }
}
