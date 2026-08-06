using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IsintuWebsite.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryStatus { get; set; } // Pending, Shipped, Delivered, Cancelled
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual Payment Payment { get; set; }
        public Order()
        {
            OrderItems = new List<OrderItem>();
            OrderDate = DateTime.Now;
            DeliveryStatus = "Pending";
        }
        // Adds up every line item on the order using LINQ, so the total always
        // reflects whatever is currently in OrderItems rather than a stored value.
        public decimal CalculateOrderTotal()
        {
            return OrderItems.Sum(item => item.CalculateItemTotal());
        }
        // Handy for showing customers how many individual pieces they ordered,
        // not just how many line items.
        public int GetTotalItemCount()
        {
            return OrderItems.Sum(item => item.Quantity);
        }
    }
}
