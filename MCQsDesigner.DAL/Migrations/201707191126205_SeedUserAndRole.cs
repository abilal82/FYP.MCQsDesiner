namespace MCQsDesigner.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserAndRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
                                             VALUES (N'8a79e096-052b-4057-9683-7a7443aa305a', N'min.admin@gmail.com', 0, N'AEsYc3Fakw95aUJn/HOBE4I8l2KuXPq64CKigxvh/b6YPCs6luzilCKDyysiFz9oGA==', N'467b70f2-2e2d-43b5-aa43-df05fb57d231', NULL, 0, 0, NULL, 1, 0, N'Admin')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'df696c9b-fa26-4f46-b2b1-ad753ea50361', N'Admin')
                    

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8a79e096-052b-4057-9683-7a7443aa305a', N'df696c9b-fa26-4f46-b2b1-ad753ea50361')
                    ");
        }
        
        public override void Down()
        {
        }
    }
}
