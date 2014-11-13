namespace Crm.Data.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueLogin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "Login", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("dbo.Users", "Login", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Login" });
            AlterColumn("dbo.Users", "Login", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 64));
        }
    }
}
