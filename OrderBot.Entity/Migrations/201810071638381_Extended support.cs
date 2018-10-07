namespace OrderBot.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Extendedsupport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupportRequests",
                c => new
                    {
                        SupportId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        OrderNumber = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupportId);
            
            CreateTable(
                "dbo.SupportRequestMessages",
                c => new
                    {
                        SupportMessageId = c.Int(nullable: false, identity: true),
                        SupportId = c.Int(nullable: false),
                        MessageDate = c.DateTime(nullable: false),
                        SupportMessage = c.String(),
                    })
                .PrimaryKey(t => t.SupportMessageId)
                .ForeignKey("dbo.SupportRequests", t => t.SupportId, cascadeDelete: true)
                .Index(t => t.SupportId);
            
            DropTable("dbo.SupportModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SupportModels",
                c => new
                    {
                        SupportId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        OrderNumber = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.SupportId);
            
            DropForeignKey("dbo.SupportRequestMessages", "SupportId", "dbo.SupportRequests");
            DropIndex("dbo.SupportRequestMessages", new[] { "SupportId" });
            DropTable("dbo.SupportRequestMessages");
            DropTable("dbo.SupportRequests");
        }
    }
}
