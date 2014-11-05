namespace Crm.Data.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 64),
                        LastName = c.String(nullable: false, maxLength: 128),
                        DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        PhoneType = c.Byte(nullable: false),
                        PhoneNr = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.ClientOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Performed = c.DateTime(nullable: false),
                        Type = c.Byte(nullable: false),
                        Callback = c.DateTime(),
                        Amount = c.Decimal(storeType: "money"),
                        Comment = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 64),
                        LastName = c.String(nullable: false, maxLength: 128),
                        Login = c.String(nullable: false, maxLength: 64),
                        Password = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientOperations", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Contacts", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientOperations", new[] { "ClientId" });
            DropIndex("dbo.Contacts", new[] { "ClientId" });
            DropTable("dbo.Users");
            DropTable("dbo.ClientOperations");
            DropTable("dbo.Contacts");
            DropTable("dbo.Clients");
        }
    }
}
