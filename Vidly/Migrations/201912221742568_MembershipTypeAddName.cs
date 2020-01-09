namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeAddName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
