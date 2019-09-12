using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Car
    {
        [Key]
        public string LicensePlate { get; set; }
        [Required]
        public string Owner { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public bool IsBlocked { get; set; }

        public string BlockerPhoneNumber { get; set; }

        [Required]
        public ParkingLot ParkingLot { get; set; }
    }
}
