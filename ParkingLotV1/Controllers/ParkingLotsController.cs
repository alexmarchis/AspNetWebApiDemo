using DataAccess;
using DataAccess.Models;
using ParkingLotV1.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ParkingLotV1.Controllers
{
    public class ParkingLotsController : ApiController
    {
        // GET api/parkinglots
        [HttpGet]
        public async Task<IEnumerable<string>> GetAll()
        {
            using(ParkingLotContext context = new ParkingLotContext())
            {
                return await context.ParkingLots.Select(pl => pl.Name).ToListAsync();
            }
        }

        // POST api/parkinglots
        [HttpPost]
        public async Task<IHttpActionResult> AddParkingLot(ParkingLotModel parkingLot)
        {
            if (ModelState.IsValid == false) return BadRequest("Invalid parking lot");

            using (ParkingLotContext context = new ParkingLotContext())
            {
                ParkingLot existingLot = await context.ParkingLots.FindAsync(parkingLot.Name);
                if(existingLot != null) return BadRequest("Parking lot already exists");

                ParkingLot newLot = new ParkingLot { Name = parkingLot.Name };
                context.ParkingLots.Add(newLot);
                await context.SaveChangesAsync();

                return Created("api/parkinglots", newLot);
            }
        }
    }
}
