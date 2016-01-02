namespace Handle_KNSER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspUserMember_DB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "KNSId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Fullname", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "University", c => c.String());
            AddColumn("dbo.AspNetUsers", "Year", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "Term", c => c.Int());
            AddColumn("dbo.AspNetUsers", "KNSRole", c => c.String());
            AddColumn("dbo.AspNetUsers", "isActive", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "isActive");
            DropColumn("dbo.AspNetUsers", "KNSRole");
            DropColumn("dbo.AspNetUsers", "Term");
            DropColumn("dbo.AspNetUsers", "Description");
            DropColumn("dbo.AspNetUsers", "Year");
            DropColumn("dbo.AspNetUsers", "University");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "Fullname");
            DropColumn("dbo.AspNetUsers", "KNSId");
        }
    }
}
