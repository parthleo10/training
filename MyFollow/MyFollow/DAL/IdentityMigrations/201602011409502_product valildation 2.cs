namespace MyFollow.DAL.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productvalildation2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Products", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Products", name: "UserId", newName: "User_Id");
        }
    }
}
