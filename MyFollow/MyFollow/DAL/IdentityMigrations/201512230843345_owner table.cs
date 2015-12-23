namespace MyFollow.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ownertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(nullable: false),
                        EmailId = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Description = c.String(maxLength: 100),
                        DateOfJoining = c.DateTime(),
                        FoundedIn = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Pin = c.String(),
                        PhoneNumber = c.String(),
                        WebsiteUrl = c.String(),
                        TwitterHandler = c.String(),
                        FacebookPageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Owner_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Owner_Id");
            AddForeignKey("dbo.AspNetUsers", "Owner_Id", "dbo.Owners", "Id");
            DropColumn("dbo.AspNetUsers", "OwnerName");
            DropColumn("dbo.AspNetUsers", "CompanyName");
            DropColumn("dbo.AspNetUsers", "Description");
            DropColumn("dbo.AspNetUsers", "DateOfJoining");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "FoundedIn");
            DropColumn("dbo.AspNetUsers", "Street1");
            DropColumn("dbo.AspNetUsers", "Street2");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "Pin");
            DropColumn("dbo.AspNetUsers", "WebsiteUrl");
            DropColumn("dbo.AspNetUsers", "TwitterHandler");
            DropColumn("dbo.AspNetUsers", "FacebookPageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FacebookPageUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "TwitterHandler", c => c.String());
            AddColumn("dbo.AspNetUsers", "WebsiteUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "Pin", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Street2", c => c.String());
            AddColumn("dbo.AspNetUsers", "Street1", c => c.String());
            AddColumn("dbo.AspNetUsers", "FoundedIn", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfJoining", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "OwnerName", c => c.String(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "Owner_Id", "dbo.Owners");
            DropIndex("dbo.AspNetUsers", new[] { "Owner_Id" });
            DropColumn("dbo.AspNetUsers", "Owner_Id");
            DropTable("dbo.Owners");
        }
    }
}
