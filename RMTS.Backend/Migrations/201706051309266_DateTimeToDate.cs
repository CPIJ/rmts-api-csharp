namespace RMTS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeToDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Action", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Action", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Action", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Action", "Date");
        }
    }
}
