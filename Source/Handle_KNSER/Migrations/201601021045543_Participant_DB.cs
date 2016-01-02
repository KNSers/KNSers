namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Participant_DB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participants", "PartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participants", "PartDate", c => c.DateTime(nullable: false));
        }
    }
}
