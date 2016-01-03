namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartScore_ParticipantsDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "PartScore", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participants", "PartScore");
        }
    }
}
