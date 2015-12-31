namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Event_Member_id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "MemberId", "dbo.Members");
            DropIndex("dbo.Events", new[] { "MemberId" });
            RenameColumn(table: "dbo.Events", name: "MemberId", newName: "Member_MemberId");
            AddColumn("dbo.Events", "Member_Leader_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "Member_MemberId", c => c.Int());
            CreateIndex("dbo.Events", "Member_MemberId");
            AddForeignKey("dbo.Events", "Member_MemberId", "dbo.Members", "MemberId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Member_MemberId", "dbo.Members");
            DropIndex("dbo.Events", new[] { "Member_MemberId" });
            AlterColumn("dbo.Events", "Member_MemberId", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "Member_Leader_Id");
            RenameColumn(table: "dbo.Events", name: "Member_MemberId", newName: "MemberId");
            CreateIndex("dbo.Events", "MemberId");
            AddForeignKey("dbo.Events", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
        }
    }
}
