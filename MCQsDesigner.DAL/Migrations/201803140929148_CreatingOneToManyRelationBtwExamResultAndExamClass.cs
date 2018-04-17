namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingOneToManyRelationBtwExamResultAndExamClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamResults", "ExamId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExamResults", "ExamId");
            AddForeignKey("dbo.ExamResults", "ExamId", "dbo.Exams", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamResults", "ExamId", "dbo.Exams");
            DropIndex("dbo.ExamResults", new[] { "ExamId" });
            DropColumn("dbo.ExamResults", "ExamId");
        }
    }
}
