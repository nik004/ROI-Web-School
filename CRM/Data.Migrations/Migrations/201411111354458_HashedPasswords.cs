namespace Crm.Data.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HashedPasswords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Hash", c => c.Binary(maxLength: 20, fixedLength: true));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 64));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 128));
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String(maxLength: 16));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 64));
            DropColumn("dbo.Users", "Hash");
        }
    }
}
