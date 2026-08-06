using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsintuWebsite.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Amount { get; set; }
        public string Method { get; set; } // Credit Card, PayPal, Bank Transfer
        public string Status { get; set; } // Pending, Completed, Failed
        public Payment()
        {
            PaymentDate = DateTime.Now;
            Status = "Pending";
        }
    }
}
