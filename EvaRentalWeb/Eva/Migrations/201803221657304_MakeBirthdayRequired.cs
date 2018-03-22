namespace Eva.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeBirthdayRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime());
        }
    }
}
