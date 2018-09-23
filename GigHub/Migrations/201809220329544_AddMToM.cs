namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMToM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Relationships", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Relationships", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            CreateIndex("dbo.Relationships", "ApplicationUser_Id");
            CreateIndex("dbo.Relationships", "ApplicationUser_Id1");
            AddForeignKey("dbo.Relationships", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Relationships", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relationships", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Relationships", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Relationships", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Relationships", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Relationships", "ApplicationUser_Id1");
            DropColumn("dbo.Relationships", "ApplicationUser_Id");
        }
    }
}
