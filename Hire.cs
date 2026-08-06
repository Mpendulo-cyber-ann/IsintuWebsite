using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsintuWebsite.Models
{
    // Tracks the actual hire period for a rented item, separate from the order
    // itself, since a customer might return an item late and owe an extra fee.
    public class Hire
    {
        public int HireId { get; set; }
        public int OrderItemId { get; set; }
        public virtual OrderItem OrderItem { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        [Column(TypeName = "decimal")]
        public decimal LateFeePerDay { get; set; } = 100.00m;
        // Works out a late fee if the attire came back after the agreed return date.
        // Returns 0 if it was returned on time or hasn't been returned yet.
        public decimal CalculateLateFee()
        {
            if (ActualReturnDate == null || ActualReturnDate <= ReturnDate)
            {
                return 0m;
            }

            int daysLate = (ActualReturnDate.Value.Date - ReturnDate.Date).Days;
            return daysLate * LateFeePerDay;
        }
    }
}
