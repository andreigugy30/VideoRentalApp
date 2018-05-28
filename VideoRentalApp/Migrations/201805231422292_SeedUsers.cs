namespace VideoRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'15bca0c1-cdf0-48a0-9296-8686d0aea355', N'andrei.gugy@gmail.com', 0, N'AFDuo/tAqC8hCf+Mmi6SyTS2C16jEkItypKEgTo+cfyDlay5HBKWwAOPaJQ4l6OsHw==', N'2c852e4a-90a5-4a65-9831-84bb34d4c539', NULL, 0, 0, NULL, 1, 0, N'andrei.gugy@gmail.com')
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4926bd3a-3c3d-4fc8-93a6-4dc101757159', N'guest@yahoo.com', 0, N'AE647DvKRIJoVK0a1bSWJpQLi4uU0s34e/XgtCsvCCbKkUYUKgA1Jo7GtocwR08U5Q==', N'619b0c31-4ca2-4aba-be6d-82ccf528430c', NULL, 0, 0, NULL, 1, 0, N'guest@yahoo.com')
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'82c1480f-e46a-4e62-aac1-91b093eea2f8', N'admin@yahoo.com', 0, N'ANzzrG5HMWbXDhvxTV5iaAIQIwq0PUt9BA1TeTWui6Ux7tOcFjFk3LXiynbNv6VmzA==', N'cfc29e87-b249-4feb-b094-1c51d3e4659b', NULL, 0, 0, NULL, 1, 0, N'admin@yahoo.com')
        INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2ece62b7-3377-425d-8234-8d6871dd1e6e', N'CanManageMovies')
        INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'82c1480f-e46a-4e62-aac1-91b093eea2f8', N'2ece62b7-3377-425d-8234-8d6871dd1e6e')


                ");
        }
        
        public override void Down()
        {
        }
    }
}
