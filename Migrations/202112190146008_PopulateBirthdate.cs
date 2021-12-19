namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Customers SET Birthdate='1995-12-15' where id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
