namespace IsintuWebsite.Models
{
    public class OrderConfirmationViewModel
    {
        public int OrderId { get; set; }
        public string AttireName { get; set; }
        public string CustomerName { get; set; 
        public string OrderType { get; set; }
        public int Quantity { get; set; }
        public int RentalDays { get; set; }
        public bool IncludeAccessories { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
