namespace Ali_ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userbuyersmerchants : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBuyers", "MerchantID", c => c.Int(nullable: false));
            CreateIndex("dbo.UserBuyers", "MerchantID");
            AddForeignKey("dbo.UserBuyers", "MerchantID", "dbo.Merchants", "MerchantID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBuyers", "MerchantID", "dbo.Merchants");
            DropIndex("dbo.UserBuyers", new[] { "MerchantID" });
            DropColumn("dbo.UserBuyers", "MerchantID");
        }
    }
}
