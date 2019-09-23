using System.ComponentModel.DataAnnotations;

namespace ParkingLotV1.Models
{
    public class ParkingLotModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}