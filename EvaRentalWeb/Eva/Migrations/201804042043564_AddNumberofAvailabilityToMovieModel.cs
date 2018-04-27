namespace Eva.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberofAvailabilityToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberOfAvailability", c => c.Byte(nullable: false));
            Sql("UPDATE Movies SET NumberOfAvailability = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberOfAvailability");
        }
    }
}
