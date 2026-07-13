using System;

namespace IsintuWebsite.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int? DriverId { get; set; }

        public virtual Driver Driver { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Status { get; set; } // Pending, Delivered, Failed

        public string Address { get; set; }

        public Delivery()
        {
            Status = "Pending";
        }
    }
}
