namespace RMTS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CopiedFromFrondEnd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Action", "Completed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Address", "HouseNumber", c => c.String());
            DropColumn("dbo.Action", "IsCompleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Action", "IsCompleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Address", "HouseNumber");
            DropColumn("dbo.Action", "Completed");
        }
    }
}
