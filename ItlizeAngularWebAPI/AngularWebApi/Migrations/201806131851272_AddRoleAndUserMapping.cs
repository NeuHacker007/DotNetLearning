namespace AngularWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleAndUserMapping : DbMigration
    {
        public override void Up()
        {
            Sql("insert into AspNetUserRoles (RoleId,UserId) values (1,1)");
            Sql("insert into AspNetUserRoles (RoleId,UserId) values (2,2)");
            Sql("insert into AspNetUserRoles (RoleId,UserId) values (3,3)");
        }
        
        public override void Down()
        {
        }
    }
}
