namespace Movie_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0f2b3bc4-66f9-4851-b946-8de75c24094d', N'admin@vidly.com', 0, N'AA1SfYFIgYXDCpuy4tvUO1gtt5d7sXESqZSoXSvugFJu0voZcGG7tJHmKrbG1WeSTg==', N'ca649b01-5bd5-4038-8927-3d537724a4ab', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b98ec81c-0629-4a5b-bbfd-992d2fb4c8d5', N'guest@vidly.com', 0, N'AIRF3RHbKTtgKgb63jAn496wjSXl/Wjtd29CkAbCW2KGlf7RjxBDOrI4O0ggW6M5Eg==', N'f3528863-de56-4b1d-acf9-eeb553c2bd5a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b407d949-4960-48aa-807a-13cbcc77a91f', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0f2b3bc4-66f9-4851-b946-8de75c24094d', N'b407d949-4960-48aa-807a-13cbcc77a91f')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
