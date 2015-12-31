namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Event_Member_change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "MemberLeader", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "Member_Leader_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Member_Leader_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "MemberLeader");
        }
    }
}
