namespace MyFollow.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialpa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "Password", c => c.String());
            AlterColumn("dbo.Owners", "OwnerName", c => c.String());
            AlterColumn("dbo.Owners", "Email", c => c.String());
            AlterColumn("dbo.Owners", "CompanyName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Owners", "CompanyName", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "OwnerName", c => c.String(nullable: false));
            DropColumn("dbo.Owners", "Password");
        }
    }
}
