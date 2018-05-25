namespace AngularWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateExistingDataInTable : DbMigration
    {
        public override void Up()
        {
            Sql("update Tasks set Status = 'Open',Quote = 'Quote1' where Id=1");
            Sql("update Tasks set Status = 'Open',Quote = 'Quote2' where Id=2");
            Sql("update Tasks set Status = 'Open',Quote = 'Quote3' where Id=3");
            Sql("update Tasks set Status = 'Open',Quote = 'Quote4' where Id=4");
            Sql("update Tasks set Status = 'Open',Quote = 'Quote5' where Id=5");
            Sql("update Tasks set Status = 'Open',Quote = 'Quote6' where Id=6");
            Sql("update Tasks set Status = 'Open',Quote = 'Quote7' where Id=7");
            Sql("update Tasks set Status = 'Open',Quote = 'Quote8' where Id=8");
        }
        
        public override void Down()
        {
        }
    }
}
