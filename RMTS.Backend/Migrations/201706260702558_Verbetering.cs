namespace RMTS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Verbetering : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Status", "ProspectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Status", "ProspectId", c => c.Int(nullable: false));
        }
    }
}
