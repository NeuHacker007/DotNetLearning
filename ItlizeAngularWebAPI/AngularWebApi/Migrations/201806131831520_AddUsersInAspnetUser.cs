namespace AngularWebApi.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUsersInAspnetUser : DbMigration
    {
        public override void Up()
        {
            Sql("insert into AspNetUsers(Id,Email,EmailConfirmed,PasswordHash,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,UserName) values (1, 'ivan@itlize.com', 1, '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', '8573008962', 1, 0, 0, 0, 'Ivan')");
            Sql("insert into AspNetUsers(Id,Email,EmailConfirmed,PasswordHash,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,UserName) values (2,'Anderew@tlize.com',1,'d4735e3a265e16eee03f59718b9b5d03019c07d8b6c51f90da3a666eec13ab35','8573008961',1,0,0,0,'Anderew')");
            Sql("insert into AspNetUsers(Id,Email,EmailConfirmed,PasswordHash,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,UserName) values (3,'Henry@tlize.com',1,'4e07408562bedb8b60ce05c1decfe3ad16b72230967de01f640b7e4729b49fce','8573008960',1,0,0,0,'Henry')");
        }

        public override void Down()
        {
        }
    }
}
