namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExamQuestionTableAndRelationWithExam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionTitle = c.String(maxLength: 255),
                        OptionA = c.String(nullable: false, maxLength: 25),
                        OptionB = c.String(nullable: false, maxLength: 25),
                        OptionC = c.String(nullable: false, maxLength: 25),
                        OptionD = c.String(nullable: false, maxLength: 25),
                        CorrectAnswer = c.String(nullable: false),
                        Marks = c.Byte(nullable: false),
                        ExamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .Index(t => t.ExamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamQuestions", "ExamID", "dbo.Exams");
            DropIndex("dbo.ExamQuestions", new[] { "ExamID" });
            DropTable("dbo.ExamQuestions");
        }
    }
}
