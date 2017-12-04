namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedStudentAndRelationBetweenApplicationUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentProfiles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        RollNumber = c.String(nullable: false, maxLength: 25),
                        Session = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentProfiles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.StudentProfiles", new[] { "UserId" });
            DropTable("dbo.StudentProfiles");
        }
    }
}
