namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropDateAdded1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "DateAdded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
