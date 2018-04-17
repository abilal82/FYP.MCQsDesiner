namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingTableAndAttributeDatatype : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Results", newName: "ExamResults");
            AlterColumn("dbo.ExamResults", "MarksObtained", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExamResults", "MarksObtained", c => c.String(nullable: false, maxLength: 20));
            RenameTable(name: "dbo.ExamResults", newName: "Results");
        }
    }
}
