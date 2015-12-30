namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeRequest_DB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "LetterId_LetterId", "dbo.Letters");
            DropForeignKey("dbo.Requests", "MemberId_MemberId", "dbo.Members");
            DropIndex("dbo.Requests", new[] { "LetterId_LetterId" });
            DropIndex("dbo.Requests", new[] { "MemberId_MemberId" });
            RenameColumn(table: "dbo.Requests", name: "LetterId_LetterId", newName: "LetterId");
            RenameColumn(table: "dbo.Requests", name: "MemberId_MemberId", newName: "MemberId");
            AlterColumn("dbo.Requests", "LetterId", c => c.Int(nullable: false));
            AlterColumn("dbo.Requests", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "LetterId");
            CreateIndex("dbo.Requests", "MemberId");
            AddForeignKey("dbo.Requests", "LetterId", "dbo.Letters", "LetterId", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Requests", "LetterId", "dbo.Letters");
            DropIndex("dbo.Requests", new[] { "MemberId" });
            DropIndex("dbo.Requests", new[] { "LetterId" });
            AlterColumn("dbo.Requests", "MemberId", c => c.Int());
            AlterColumn("dbo.Requests", "LetterId", c => c.Int());
            RenameColumn(table: "dbo.Requests", name: "MemberId", newName: "MemberId_MemberId");
            RenameColumn(table: "dbo.Requests", name: "LetterId", newName: "LetterId_LetterId");
            CreateIndex("dbo.Requests", "MemberId_MemberId");
            CreateIndex("dbo.Requests", "LetterId_LetterId");
            AddForeignKey("dbo.Requests", "MemberId_MemberId", "dbo.Members", "MemberId");
            AddForeignKey("dbo.Requests", "LetterId_LetterId", "dbo.Letters", "LetterId");
        }
    }
}
