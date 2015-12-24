namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembers_isActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "isActive");
        }
    }
}
