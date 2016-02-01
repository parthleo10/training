namespace MyFollow.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ProductIntro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductIntro", c => c.String(nullable: false, maxLength: 140));
        }
    }
}
