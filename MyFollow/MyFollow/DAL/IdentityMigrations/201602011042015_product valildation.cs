namespace MyFollow.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productvalildation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.Products", "ProductDetails", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductDetails", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
