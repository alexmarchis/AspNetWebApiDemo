using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class ParkingLot
    {
        [Key]
        public string Name { get; set; }
    }
}
