namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOneToManyDegreeProgramAndCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(),
                        CreditHour = c.Byte(nullable: false),
                        CourseCode = c.String(),
                        CourseOutLine = c.String(),
                        DegreeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.DegreePrograms", t => t.DegreeID, cascadeDelete: true)
                .Index(t => t.DegreeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "DegreeID", "dbo.DegreePrograms");
            DropIndex("dbo.Courses", new[] { "DegreeID" });
            DropTable("dbo.Courses");
        }
    }
}
