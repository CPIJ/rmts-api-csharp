namespace RMTS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prospect", "Status_Id", "dbo.Status");
            DropIndex("dbo.ActionType", "U_Content");
            DropIndex("dbo.Prospect", "U_Profession");
            DropIndex("dbo.Prospect", "U_EmailAddress");
            DropIndex("dbo.Prospect", new[] { "Status_Id" });
            DropIndex("dbo.Status", "U_Name");
            DropIndex("dbo.User", "U_Username");
            AlterColumn("dbo.Action", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.ActionType", "Content", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.Prospect", "Profession", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.Prospect", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Prospect", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Prospect", "EmailAddress", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.Prospect", "Status_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.ActionType", "Content", unique: true, name: "U_Content");
            CreateIndex("dbo.Prospect", "Profession", unique: true, name: "U_Profession");
            CreateIndex("dbo.Prospect", "EmailAddress", unique: true, name: "U_EmailAddress");
            CreateIndex("dbo.Prospect", "Status_Id");
            CreateIndex("dbo.Status", "Name", unique: true, name: "U_Name");
            CreateIndex("dbo.User", "Username", unique: true, name: "U_Username");
            AddForeignKey("dbo.Prospect", "Status_Id", "dbo.Status", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prospect", "Status_Id", "dbo.Status");
            DropIndex("dbo.User", "U_Username");
            DropIndex("dbo.Status", "U_Name");
            DropIndex("dbo.Prospect", new[] { "Status_Id" });
            DropIndex("dbo.Prospect", "U_EmailAddress");
            DropIndex("dbo.Prospect", "U_Profession");
            DropIndex("dbo.ActionType", "U_Content");
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Username", c => c.String(maxLength: 450));
            AlterColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.Status", "Name", c => c.String(maxLength: 450));
            AlterColumn("dbo.Prospect", "Status_Id", c => c.Int());
            AlterColumn("dbo.Prospect", "EmailAddress", c => c.String(maxLength: 450));
            AlterColumn("dbo.Prospect", "Surname", c => c.String());
            AlterColumn("dbo.Prospect", "FirstName", c => c.String());
            AlterColumn("dbo.Prospect", "Profession", c => c.String(maxLength: 450));
            AlterColumn("dbo.ActionType", "Content", c => c.String(maxLength: 450));
            AlterColumn("dbo.Action", "Location", c => c.String());
            CreateIndex("dbo.User", "Username", unique: true, name: "U_Username");
            CreateIndex("dbo.Status", "Name", unique: true, name: "U_Name");
            CreateIndex("dbo.Prospect", "Status_Id");
            CreateIndex("dbo.Prospect", "EmailAddress", unique: true, name: "U_EmailAddress");
            CreateIndex("dbo.Prospect", "Profession", unique: true, name: "U_Profession");
            CreateIndex("dbo.ActionType", "Content", unique: true, name: "U_Content");
            AddForeignKey("dbo.Prospect", "Status_Id", "dbo.Status", "Id");
        }
    }
}
