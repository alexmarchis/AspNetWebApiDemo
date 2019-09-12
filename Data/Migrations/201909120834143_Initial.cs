namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        LicensePlate = c.String(nullable: false, maxLength: 128),
                        Owner = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                        BlockerPhoneNumber = c.String(),
                        ParkingLot_Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LicensePlate)
                .ForeignKey("dbo.ParkingLots", t => t.ParkingLot_Name, cascadeDelete: true)
                .Index(t => t.ParkingLot_Name);
            
            CreateTable(
                "dbo.ParkingLots",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ParkingLot_Name", "dbo.ParkingLots");
            DropIndex("dbo.Cars", new[] { "ParkingLot_Name" });
            DropTable("dbo.ParkingLots");
            DropTable("dbo.Cars");
        }
    }
}
