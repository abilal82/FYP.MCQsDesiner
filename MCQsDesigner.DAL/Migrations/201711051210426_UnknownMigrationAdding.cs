namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnknownMigrationAdding : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExamQuestions", "CorrectAnswer", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExamQuestions", "CorrectAnswer", c => c.String(nullable: false));
        }
    }
}
