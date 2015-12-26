namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId_Members : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "UserId");
        }
    }
}
