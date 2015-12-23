namespace MyFollow.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        EmailId = c.String(nullable: false),
                        DateOfJoining = c.DateTime(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Pin = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.AspNetUsers", "User_UserId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "User_UserId");
            AddForeignKey("dbo.AspNetUsers", "User_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "User_UserId", "dbo.Users");
            DropIndex("dbo.AspNetUsers", new[] { "User_UserId" });
            DropColumn("dbo.AspNetUsers", "User_UserId");
            DropTable("dbo.Users");
        }
    }
}
