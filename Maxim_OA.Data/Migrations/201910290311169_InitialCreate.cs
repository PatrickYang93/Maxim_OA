namespace Maxim_OA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        make = c.String(),
                        model = c.String(),
                        color = c.String(),
                        year = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                        TCC_Rating = c.Double(nullable: false),
                        Hwy_MPG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
