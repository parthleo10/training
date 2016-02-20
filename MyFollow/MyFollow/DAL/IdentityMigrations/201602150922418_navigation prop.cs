namespace MyFollow.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navigationprop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EndUsers",
                c => new
                    {
                        EndUserId = c.Int(nullable: false, identity: true),
                        EndUserName = c.String(nullable: false),
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
                .PrimaryKey(t => t.EndUserId);
            
            CreateTable(
                "dbo.FollowProducts",
                c => new
                    {
                        FollowProductId = c.Int(nullable: false, identity: true),
                        IsFollowed = c.Boolean(nullable: false),
                        ProductId = c.Int(nullable: false),
                        EndUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FollowProductId)
                .ForeignKey("dbo.EndUsers", t => t.EndUserId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.EndUserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDetails = c.String(),
                        ProductPrice = c.Double(nullable: false),
                        UserId = c.String(maxLength: 128),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Description = c.String(),
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
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        OwnerName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        EndUser_EndUserId = c.Int(),
                        Invitation_Id = c.Int(),
                        Owner_OwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EndUsers", t => t.EndUser_EndUserId)
                .ForeignKey("dbo.Invitations", t => t.Invitation_Id)
                .ForeignKey("dbo.Owners", t => t.Owner_OwnerId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.EndUser_EndUserId)
                .Index(t => t.Invitation_Id)
                .Index(t => t.Owner_OwnerId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InviteOwnerName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FollowProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Owner_OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Users", "Invitation_Id", "dbo.Invitations");
            DropForeignKey("dbo.Users", "EndUser_EndUserId", "dbo.EndUsers");
            DropForeignKey("dbo.Products", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.FollowProducts", "EndUserId", "dbo.EndUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Users", new[] { "Owner_OwnerId" });
            DropIndex("dbo.Users", new[] { "Invitation_Id" });
            DropIndex("dbo.Users", new[] { "EndUser_EndUserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Products", new[] { "OwnerId" });
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.FollowProducts", new[] { "EndUserId" });
            DropIndex("dbo.FollowProducts", new[] { "ProductId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Invitations");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Owners");
            DropTable("dbo.Products");
            DropTable("dbo.FollowProducts");
            DropTable("dbo.EndUsers");
        }
    }
}
