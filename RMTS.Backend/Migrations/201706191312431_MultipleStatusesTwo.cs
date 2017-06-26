namespace RMTS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultipleStatusesTwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Status", "ProspectId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Status", "ProspectId");
        }
    }
}
