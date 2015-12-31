namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Member_Leader : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Member_MemberId", "dbo.Members");
            DropIndex("dbo.Events", new[] { "Member_MemberId" });
            RenameColumn(table: "dbo.Events", name: "Member_MemberId", newName: "MemberId");
            AlterColumn("dbo.Events", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "MemberId");
            AddForeignKey("dbo.Events", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
            DropColumn("dbo.Events", "MemberLeader");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "MemberLeader", c => c.Int(nullable: false));
            DropForeignKey("dbo.Events", "MemberId", "dbo.Members");
            DropIndex("dbo.Events", new[] { "MemberId" });
            AlterColumn("dbo.Events", "MemberId", c => c.Int());
            RenameColumn(table: "dbo.Events", name: "MemberId", newName: "Member_MemberId");
            CreateIndex("dbo.Events", "Member_MemberId");
            AddForeignKey("dbo.Events", "Member_MemberId", "dbo.Members", "MemberId");
        }
    }
}
