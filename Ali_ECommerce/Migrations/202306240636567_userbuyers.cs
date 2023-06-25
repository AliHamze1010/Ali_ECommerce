namespace Ali_ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userbuyers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserBuyers",
                c => new
                    {
                        UserBuyerID = c.Int(nullable: false, identity: true),
                        UserBuyerName = c.String(),
                    })
                .PrimaryKey(t => t.UserBuyerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserBuyers");
        }
    }
}
