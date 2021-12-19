namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetailsInMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleasedDate");
        }
    }
}
