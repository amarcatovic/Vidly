namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(genre) VALUES('Comedy')");
            Sql("INSERT INTO Genres(genre) VALUES('Action')");
            Sql("INSERT INTO Genres(genre) VALUES('Family')");
            Sql("INSERT INTO Genres(genre) VALUES('Romance')");
            Sql("INSERT INTO Genres(genre) VALUES('Adult')");
            Sql("INSERT INTO Genres(genre) VALUES('Cartoon')");
        }
        
        public override void Down()
        {
        }
    }
}
