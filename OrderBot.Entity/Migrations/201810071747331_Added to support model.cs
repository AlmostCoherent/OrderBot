namespace OrderBot.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedtosupportmodel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        MyProperty = c.Int(nullable: false, identity: true),
                        Temp = c.String(),
                    })
                .PrimaryKey(t => t.MyProperty);
            
        }
    }
}
