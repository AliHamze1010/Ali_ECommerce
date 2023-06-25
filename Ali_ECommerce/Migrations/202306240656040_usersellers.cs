namespace Ali_ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersellers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSellers",
                c => new
                    {
                        UserSellerID = c.Int(nullable: false, identity: true),
                        UserSellerName = c.String(),
                        UserSellerBusiness = c.String(),
                    })
                .PrimaryKey(t => t.UserSellerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserSellers");
        }
    }
}
