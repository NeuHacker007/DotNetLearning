namespace AngularWebApi.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUserRolesInAspNetRoles : DbMigration
    {
        public override void Up()
        {
            Sql("insert into AspNetRoles(Id, Name) values(1,'Admin')");
            Sql("insert into AspNetRoles(Id, Name) values(2,'Manager')");
            Sql("insert into AspNetRoles(Id, Name) values(3,'TeamLead')");
            Sql("insert into AspNetRoles(Id, Name) values(4,'TeamMember')");

        }
        public override void Down()
        {
        }
    }
}

