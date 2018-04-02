namespace Eva.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'32a1a993-e0fb-41a4-8fbb-3606f16ee64f', N'admin@gmail.com', 0, N'AH3symi0g8ls1R1YalZ1Pwyykkf2XDCt/R6j3WHirzO9VrFvQdPuBl6kDEy7eoHCVw==', N'cfa695fa-c0bd-4f6a-bc08-227d5f994f49', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9db8ab10-9422-4572-902f-09147b25023d', N'guest@gmail.com', 0, N'AFnTvWZeczJLVe+HT1eZyuAT0y2jJMHLLWRf+y/sWZQ5tXC4huOlD8v4DvXoWtNPKA==', N'70d6aa2d-7df8-450d-b207-7eb4d9c31566', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7c456f9f-f404-4a08-baec-76c8fa2c1f38', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'32a1a993-e0fb-41a4-8fbb-3606f16ee64f', N'7c456f9f-f404-4a08-baec-76c8fa2c1f38')
        ");
        }

        public override void Down()
        {
        }
    }
}
