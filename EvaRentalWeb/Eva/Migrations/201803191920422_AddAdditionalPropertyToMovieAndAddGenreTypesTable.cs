namespace Eva.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdditionalPropertyToMovieAndAddGenreTypesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ReleasedDate = c.DateTime(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenreTypes", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.GenreTypes");
            DropTable("dbo.Movies");
        }
    }
}
