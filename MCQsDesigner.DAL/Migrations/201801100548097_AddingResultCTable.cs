namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingResultCTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarksObtained = c.String(nullable: false, maxLength: 20),
                        CorrectAnswer = c.Int(nullable: false),
                        InCorrectAnswer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Results");
        }
    }
}
