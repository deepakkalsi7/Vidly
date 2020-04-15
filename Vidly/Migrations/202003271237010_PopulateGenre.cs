namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(GenreName)values('Comedy')");
            Sql("Insert into Genres(GenreName)values('Thriller')");
            Sql("Insert into Genres(GenreName)values('Crime')");
            Sql("Insert into Genres(GenreName)values('Love')");
            Sql("Insert into Genres(GenreName)values('Horror')");
            Sql("Insert into Genres(GenreName)values('Comedy')");
            Sql("Insert into Genres(GenreName)values('Gangster')");
            Sql("Insert into Genres(GenreName)values('Fiction')");
            Sql("Insert into Genres(GenreName)values('Biography')");
        }
        
        public override void Down()
        {
        }
    }
}
