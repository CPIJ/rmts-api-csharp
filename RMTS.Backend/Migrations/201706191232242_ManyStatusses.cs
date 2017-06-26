namespace RMTS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyStatusses : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Prospect", name: "Status_Id", newName: "StatusId");
            RenameIndex(table: "dbo.Prospect", name: "IX_Status_Id", newName: "IX_StatusId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Prospect", name: "IX_StatusId", newName: "IX_Status_Id");
            RenameColumn(table: "dbo.Prospect", name: "StatusId", newName: "Status_Id");
        }
    }
}
