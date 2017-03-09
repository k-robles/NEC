namespace FunFacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FunFacts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FunFacts");
        }
    }
}
