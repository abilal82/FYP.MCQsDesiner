namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNewAttributesIntoExamResultAndRelationsWithStudentFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamResults", "TotalMarks", c => c.Int(nullable: false));
            AddColumn("dbo.ExamResults", "NoOfAttemptedQuestion", c => c.Int(nullable: false));
            AddColumn("dbo.ExamResults", "TotalNoOfQuestion", c => c.Int(nullable: false));
            AddColumn("dbo.ExamResults", "StudentProfileId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ExamResults", "StudentProfileId");
            AddForeignKey("dbo.ExamResults", "StudentProfileId", "dbo.StudentProfiles", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamResults", "StudentProfileId", "dbo.StudentProfiles");
            DropIndex("dbo.ExamResults", new[] { "StudentProfileId" });
            DropColumn("dbo.ExamResults", "StudentProfileId");
            DropColumn("dbo.ExamResults", "TotalNoOfQuestion");
            DropColumn("dbo.ExamResults", "NoOfAttemptedQuestion");
            DropColumn("dbo.ExamResults", "TotalMarks");
        }
    }
}
