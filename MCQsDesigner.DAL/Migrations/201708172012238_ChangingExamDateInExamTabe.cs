namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingExamDateInExamTabe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exams", "ExamDate", c => c.DateTime());
            AlterColumn("dbo.Exams", "StartingTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exams", "StartingTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Exams", "ExamDate", c => c.DateTime(nullable: false));
        }
    }
}
