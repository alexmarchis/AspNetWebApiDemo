namespace Data.Migrations
{
    using DataAccess.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.ParkingLotContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.ParkingLotContext context)
        {
            context.ParkingLots.AddOrUpdate(new ParkingLot { Name = "Jungla"});
            context.ParkingLots.AddOrUpdate(new ParkingLot { Name = "UBC"});
            context.ParkingLots.AddOrUpdate(new ParkingLot { Name = "Iulius"});

            context.Cars.AddOrUpdate(new Car {
                LicensePlate = "CJ-01-BOS",
                Owner = "Sefu Mare",
                PhoneNumber = "0740-555-999",
                IsBlocked = false,
                BlockerPhoneNumber = null,
                ParkingLot = context.ParkingLots.Find("UBC")
            });

            context.Cars.AddOrUpdate(new Car
            {
                LicensePlate = "CJ-87-LLL",
                Owner = "Ghita",
                PhoneNumber = "0740-123-555",
                IsBlocked = true,
                BlockerPhoneNumber = "0770-767-541",
                ParkingLot = context.ParkingLots.Find("Jungla")
            });

            context.Cars.AddOrUpdate(new Car
            {
                LicensePlate = "CJ-34-LAT",
                Owner = "Vasile",
                PhoneNumber = "0770-767-541",
                IsBlocked = false,
                BlockerPhoneNumber = null,
                ParkingLot = context.ParkingLots.Find("Jungla")
            });
        }
    }
}
