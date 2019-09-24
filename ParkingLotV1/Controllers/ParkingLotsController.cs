using DataAccess;
using DataAccess.Models;
using ParkingLotV1.Models;
using ParkingLotV1.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ParkingLotV1.Controllers
{
    public class ParkingLotsController : ApiController
    {
        private ISpecialService specialService;

        public ParkingLotsController(ISpecialService specialService)
        {
            this.specialService = specialService;
        }

        // GET api/parkinglots
        [HttpGet]
        public async Task<IEnumerable<string>> GetAll()
        {
            using(ParkingLotContext context = new ParkingLotContext())
            {
                return await context.ParkingLots.Select(pl => pl.Name).ToListAsync();
            }
        }

        [HttpGet]
        [Route("api/justspecial")]
        public string JustSpecial()
        {
            return specialService.SpecialMethod();
        }

        // POST api/parkinglots
        [HttpPost]
        public async Task<IHttpActionResult> AddParkingLot(ParkingLotModel parkingLot)
        {
            if (ModelState.IsValid == false) return BadRequest(ModelState);

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
