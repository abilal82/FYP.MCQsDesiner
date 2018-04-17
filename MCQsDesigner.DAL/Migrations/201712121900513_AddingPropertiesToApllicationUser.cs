namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPropertiesToApllicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 25));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 25));
            DropColumn("dbo.StudentProfiles", "FirstName");
            DropColumn("dbo.StudentProfiles", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentProfiles", "LastName", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.StudentProfiles", "FirstName", c => c.String(nullable: false, maxLength: 25));
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
