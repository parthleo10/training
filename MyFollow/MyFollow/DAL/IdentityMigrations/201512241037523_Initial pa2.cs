namespace MyFollow.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialpa2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "Passwordo", c => c.String());
            DropColumn("dbo.Owners", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Owners", "Password", c => c.String());
            DropColumn("dbo.Owners", "Passwordo");
        }
    }
}
