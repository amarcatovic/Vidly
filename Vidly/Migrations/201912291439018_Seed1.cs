namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2e4fccb6-0a9d-4b17-9b00-8e07d564da61', N'guest@vidly.com', 0, N'ABNLDocXQ2wd6YmQrfG8FFmWaT+99p9s2MP8mJJoJ330jEn2Tve5ZWKaP3NwFt7PZA==', N'f1a67d1f-dc12-4ea0-abfb-de7bbbec3fe0', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3bdf584e-72ee-4649-ad99-d8ddb1bb96d3', N'admin@vidly.com', 0, N'ACrThZMYBZ/p3F79ixBtFyUUTkTspayNoTEfhN/fNRR/XL1F1zn/i20LsrnKQ858sA==', N'4cbb368f-0fe9-4ac9-9425-42d291c844a7', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e3fa57d7-c5c5-4318-a860-0db23ecf78cd', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3bdf584e-72ee-4649-ad99-d8ddb1bb96d3', N'e3fa57d7-c5c5-4318-a860-0db23ecf78cd')

");
        }
        
        public override void Down()
        {
        }
    }
}
