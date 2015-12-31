namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaderEvent_DBase : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Leader_MemberId", newName: "Member_MemberId");
            RenameIndex(table: "dbo.Events", name: "IX_Leader_MemberId", newName: "IX_Member_MemberId");
            AddColumn("dbo.Events", "LeaderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "LeaderId");
            RenameIndex(table: "dbo.Events", name: "IX_Member_MemberId", newName: "IX_Leader_MemberId");
            RenameColumn(table: "dbo.Events", name: "Member_MemberId", newName: "Leader_MemberId");
        }
    }
}
