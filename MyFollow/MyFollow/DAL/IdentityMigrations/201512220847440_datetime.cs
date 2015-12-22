namespace MyFollow.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Description", c => c.String());
            AlterColumn("dbo.AspNetUsers", "DateOfJoining", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "DateOfJoining", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Description", c => c.String(maxLength: 100));
        }
    }
}
