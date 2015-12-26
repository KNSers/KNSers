namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Approval_Requests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "Approval", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "Approval");
        }
    }
}
