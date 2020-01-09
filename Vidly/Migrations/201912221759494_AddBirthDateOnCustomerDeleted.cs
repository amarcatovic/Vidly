namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateOnCustomerDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
