namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Number in Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genres_GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genres_GenreName", c => c.String());
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Loaddate", c => c.DateTime(nullable: false));
          


        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Loaddate");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "Genres_GenreName");
            DropColumn("dbo.Movies", "Genres_GenreId");
            DropColumn("dbo.Movies", "Number in Stock");
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
