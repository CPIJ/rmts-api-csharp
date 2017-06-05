namespace RMTS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DePluralize : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Actions", newName: "Action");
            RenameTable(name: "dbo.ActionTypes", newName: "ActionType");
            RenameTable(name: "dbo.Prospects", newName: "Prospect");
            RenameTable(name: "dbo.Addresses", newName: "Address");
            RenameTable(name: "dbo.Users", newName: "User");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.Address", newName: "Addresses");
            RenameTable(name: "dbo.Prospect", newName: "Prospects");
            RenameTable(name: "dbo.ActionType", newName: "ActionTypes");
            RenameTable(name: "dbo.Action", newName: "Actions");
        }
    }
}
