namespace MyFollow.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Invitation_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Invitation_Id");
            AddForeignKey("dbo.AspNetUsers", "Invitation_Id", "dbo.Invitations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Invitation_Id", "dbo.Invitations");
            DropIndex("dbo.AspNetUsers", new[] { "Invitation_Id" });
            DropColumn("dbo.AspNetUsers", "Invitation_Id");
            DropTable("dbo.Invitations");
        }
    }
}
