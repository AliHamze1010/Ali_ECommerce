namespace Ali_ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBuyers", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBuyers", "FirstName");
        }
    }
}
