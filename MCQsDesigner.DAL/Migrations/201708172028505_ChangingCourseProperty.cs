namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingCourseProperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropPrimaryKey("dbo.Courses");
            DropColumn("dbo.Courses", "CourseId");
            AddColumn("dbo.Courses", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Courses", "Id");
            AddForeignKey("dbo.Exams", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CourseId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropPrimaryKey("dbo.Courses");
            DropColumn("dbo.Courses", "Id");
            AddPrimaryKey("dbo.Courses", "CourseId");
            AddForeignKey("dbo.Exams", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}
