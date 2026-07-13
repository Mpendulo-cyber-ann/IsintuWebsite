using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace IsintuWebsite.Models
{
    public class Driver
    {
        public int DriverId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string CarDetails { get; set; }

        public string AvailabilityStatus { get; set; } // Available, Unavailable

        public virtual ICollection<Delivery> Deliveries { get; set; }

        public Driver()
        {
            Deliveries = new List<Delivery>();
            AvailabilityStatus = "Available";
        }
    }
}
