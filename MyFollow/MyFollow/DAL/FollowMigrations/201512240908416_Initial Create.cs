namespace MyFollow.DAL.FollowMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppOwner",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Desription = c.String(maxLength: 100),
                        DateOfJoining = c.DateTime(),
                        FoundedIn = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Pin = c.String(),
                        ContactNumber = c.String(),
                        WebsiteUrl = c.String(),
                        TwitterHandler = c.String(),
                        FacebookPageUrl = c.String(),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.EndUser",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        DateOfJoining = c.DateTime(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Pin = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Invitation",
                c => new
                    {
                        InvitaionId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        OwnerName = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InvitaionId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 20),
                        ProductIntro = c.String(nullable: false, maxLength: 140),
                        ProductDetails = c.String(nullable: false, maxLength: 1000),
                        Productprice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
            DropTable("dbo.Invitation");
            DropTable("dbo.EndUser");
            DropTable("dbo.AppOwner");
        }
    }
}
