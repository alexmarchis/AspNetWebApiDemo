using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DataAccess
{
    public class ParkingLotContext : DbContext
    {
        public DbSet<ParkingLot> ParkingLots { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
