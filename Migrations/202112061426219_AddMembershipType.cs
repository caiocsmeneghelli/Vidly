namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MemberShipTypesId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MemberShipTypesId");
            AddForeignKey("dbo.Customers", "MemberShipTypesId", "dbo.MemberShipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypesId", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypesId" });
            DropColumn("dbo.Customers", "MemberShipTypesId");
            DropTable("dbo.MemberShipTypes");
        }
    }
}
