namespace Eva.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateDataToGenreTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES(1, 'Action')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES(2, 'Thriller')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES(3, 'Family')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES(4, 'Romance')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES(5, 'Comedy')");

        }

        public override void Down()
        {
        }
    }
}
