namespace VideoRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTbl : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO Genres (Id, Name) VALUES(1, 'Comedy')");
            Sql("Insert INTO Genres (Id, Name) VALUES(2, 'Action')");
            Sql("Insert INTO Genres (Id, Name) VALUES(3, 'Thriller')");
            Sql("Insert INTO Genres (Id, Name) VALUES(4, 'Horror')");
            Sql("Insert INTO Genres (Id, Name) VALUES(5, 'Romantic')");
            Sql("Insert INTO Genres (Id, Name) VALUES(6, 'SF')");
        }
        
        public override void Down()
        {
        }
    }
}
