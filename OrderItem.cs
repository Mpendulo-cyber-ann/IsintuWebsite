using System.ComponentModel.DataAnnotations.Schema;

namespace IsintuWebsite.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int AttireId { get; set; }

        public virtual ClothingItem Attire { get; set; }

        // Either "Buy" or "Rent" - drives which price calculation runs below
        public string OrderType { get; set; }

        public int Quantity { get; set; }

        // Only meaningful when OrderType is "Rent". Left at 0 for purchases.
        public int RentalDays { get; set; }

        // Customers can add on the beaded accessories/headgear set for a small extra fee
        public bool IncludeAccessories { get; set; }

        [Column(TypeName = "decimal")]
        public decimal AccessoryFee { get; set; } = 150.00m;

        public virtual Hire Hire { get; set; }

        // This is where the actual pricing logic lives. Buying and renting are
        // worked out differently, and the optional accessory fee is added per item.
        public decimal CalculateItemTotal()
        {
            decimal unitPrice = Attire.GetUnitPrice(OrderType, RentalDays);
            decimal total = unitPrice * Quantity;

            if (IncludeAccessories)
            {
                total += AccessoryFee * Quantity;
            }

            return total;
        }
    }
}
