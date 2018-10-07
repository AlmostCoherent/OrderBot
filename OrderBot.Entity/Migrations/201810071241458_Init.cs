namespace OrderBot.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Supports", newName: "SupportModels");
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        MyProperty = c.Int(nullable: false, identity: true),
                        Temp = c.String(),
                    })
                .PrimaryKey(t => t.MyProperty);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tests");
            RenameTable(name: "dbo.SupportModels", newName: "Supports");
        }
    }
}
