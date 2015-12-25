namespace MyFollow.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invitations", "OwnName", c => c.String(nullable: false));
            DropColumn("dbo.Invitations", "OwnerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invitations", "OwnerName", c => c.String(nullable: false));
            DropColumn("dbo.Invitations", "OwnName");
        }
    }
}
