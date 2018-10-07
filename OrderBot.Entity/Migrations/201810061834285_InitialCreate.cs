namespace OrderBot.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Supports",
                c => new
                    {
                        SupportId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        OrderNumber = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.SupportId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Supports");
        }
    }
}
