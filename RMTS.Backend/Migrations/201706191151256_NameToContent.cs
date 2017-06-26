namespace RMTS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameToContent : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Status", "U_Name");
            AddColumn("dbo.Status", "Content", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.Status", "Content", unique: true, name: "U_Name");
            DropColumn("dbo.Status", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Status", "Name", c => c.String(nullable: false, maxLength: 450));
            DropIndex("dbo.Status", "U_Name");
            DropColumn("dbo.Status", "Content");
            CreateIndex("dbo.Status", "Name", unique: true, name: "U_Name");
        }
    }
}
