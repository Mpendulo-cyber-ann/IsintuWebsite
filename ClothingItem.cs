using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace IsintuWebsite.Models
{
    // Represents a traditional attire item that can either be bought or hired out.
    public class ClothingItem
    {
        public int AttireId { get; set; }

        [Required(ErrorMessage = "Please give the attire a name.")]
        [StringLength(100)]
        public string Name { get; set; }

        public string Category { get; set; } // e.g. Men, Women, Accessories

        public string Size { get; set; }

        public string Color { get; set; }

        public string Material { get; set; }

        public string Description { get; set; }

        // Default buy price for a full Isintu traditional attire set
        [Column(TypeName = "decimal")]
        public decimal BuyPrice { get; set; } = 5400.00m;

        // Rental is charged per day the attire is hired out
        [Column(TypeName = "decimal")]
        public decimal RentPricePerDay { get; set; } = 340.00m;

        public string AvailabilityStatus { get; set; } // Available, Hired, Sold

        // Path to the image inside the site's /Images folder, e.g. /Images/zulu-attire-main.jpg
        public string ImageUrl { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public ClothingItem()
        {
            OrderItems = new List<OrderItem>();
            AvailabilityStatus = "Available";
        }

        // Works out what a single unit of this item will cost, before quantity is applied.
        // orderType is either "Buy" or "Rent".
        public decimal GetUnitPrice(string orderType, int rentalDays)
        {
            if (orderType == "Rent")
            {
                if (rentalDays < 1)
                {
                    rentalDays = 1;
                }

                return RentPricePerDay * rentalDays;
            }

            return BuyPrice;
        }
    }
}
