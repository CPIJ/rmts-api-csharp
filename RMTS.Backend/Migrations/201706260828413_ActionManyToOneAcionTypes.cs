namespace RMTS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActionManyToOneAcionTypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Action", "ActionType_Id", "dbo.ActionType");
            DropIndex("dbo.Action", new[] { "ActionType_Id" });
            RenameColumn(table: "dbo.Action", name: "ActionType_Id", newName: "ActionTypeId");
            AlterColumn("dbo.Action", "ActionTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Action", "ActionTypeId");
            AddForeignKey("dbo.Action", "ActionTypeId", "dbo.ActionType", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Action", "ActionTypeId", "dbo.ActionType");
            DropIndex("dbo.Action", new[] { "ActionTypeId" });
            AlterColumn("dbo.Action", "ActionTypeId", c => c.Int());
            RenameColumn(table: "dbo.Action", name: "ActionTypeId", newName: "ActionType_Id");
            CreateIndex("dbo.Action", "ActionType_Id");
            AddForeignKey("dbo.Action", "ActionType_Id", "dbo.ActionType", "Id");
        }
    }
}
