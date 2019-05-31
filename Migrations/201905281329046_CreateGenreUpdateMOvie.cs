namespace Mosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGenreUpdateMOvie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "Genre", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Movie", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movie", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movie", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movie", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movie", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Name", c => c.String());
            DropColumn("dbo.Movie", "NumberInStock");
            DropColumn("dbo.Movie", "ReleaseDate");
            DropColumn("dbo.Movie", "DateAdded");
            DropColumn("dbo.Movie", "GenreId");
            DropColumn("dbo.Movie", "Genre");
        }
    }
}
