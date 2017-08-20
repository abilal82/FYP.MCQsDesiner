namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategryAndDegreeProgramTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 10),
                        Duration = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DegreePrograms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramTitle = c.String(maxLength: 50),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DegreePrograms", "CategoryId", "dbo.Categories");
            DropIndex("dbo.DegreePrograms", new[] { "CategoryId" });
            DropTable("dbo.DegreePrograms");
            DropTable("dbo.Categories");
        }
    }
}
