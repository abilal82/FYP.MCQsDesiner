namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExamTableAndRelationshipCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamCode = c.String(nullable: false, maxLength: 20),
                        Duration = c.Int(nullable: false),
                        ExamDate = c.DateTime(nullable: false),
                        StartingTime = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropTable("dbo.Exams");
        }
    }
}
