namespace RMTS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        Description = c.String(),
                        Location = c.String(),
                        ActionType_Id = c.Int(),
                        Prospect_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActionTypes", t => t.ActionType_Id)
                .ForeignKey("dbo.Prospects", t => t.Prospect_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.ActionType_Id)
                .Index(t => t.Prospect_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ActionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Content, unique: true, name: "U_Content");
            
            CreateTable(
                "dbo.Prospects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Profession = c.String(maxLength: 450),
                        FirstName = c.String(),
                        Infix = c.String(),
                        Surname = c.String(),
                        Phonenumber = c.String(),
                        EmailAddress = c.String(maxLength: 450),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        Address_Id = c.Int(),
                        SocialLinks_Id = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.SocialLinks", t => t.SocialLinks_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Profession, unique: true, name: "U_Profession")
                .Index(t => t.EmailAddress, unique: true, name: "U_EmailAddress")
                .Index(t => t.Address_Id)
                .Index(t => t.SocialLinks_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        Zipcode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        LinkedIn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "U_Name");
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(maxLength: 450),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true, name: "U_Username");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Actions", "Prospect_Id", "dbo.Prospects");
            DropForeignKey("dbo.Prospects", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Prospects", "SocialLinks_Id", "dbo.SocialLinks");
            DropForeignKey("dbo.Prospects", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Actions", "ActionType_Id", "dbo.ActionTypes");
            DropIndex("dbo.Users", "U_Username");
            DropIndex("dbo.Status", "U_Name");
            DropIndex("dbo.Prospects", new[] { "Status_Id" });
            DropIndex("dbo.Prospects", new[] { "SocialLinks_Id" });
            DropIndex("dbo.Prospects", new[] { "Address_Id" });
            DropIndex("dbo.Prospects", "U_EmailAddress");
            DropIndex("dbo.Prospects", "U_Profession");
            DropIndex("dbo.ActionTypes", "U_Content");
            DropIndex("dbo.Actions", new[] { "User_Id" });
            DropIndex("dbo.Actions", new[] { "Prospect_Id" });
            DropIndex("dbo.Actions", new[] { "ActionType_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Status");
            DropTable("dbo.SocialLinks");
            DropTable("dbo.Addresses");
            DropTable("dbo.Prospects");
            DropTable("dbo.ActionTypes");
            DropTable("dbo.Actions");
        }
    }
}
