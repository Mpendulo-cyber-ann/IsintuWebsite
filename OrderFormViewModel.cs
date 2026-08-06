using System.ComponentModel.DataAnnotations;

namespace IsintuWebsite.Models
{
    // This is what the Details/order page is strongly typed to. Keeping the form
    // fields on a view model like this means the controller never has to reach
    // for ViewBag to pass loose data across to the view.
    public class OrderFormViewModel
    {
        public int AttireId { get; set; }
        public ClothingItem Attire { get; set; }
        [Required(ErrorMessage = "Please enter your full name.")]
        [Display(Name = "Full Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email Address")]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Please enter your phone number.")]
        [Display(Name = "Phone Number")]
        public string CustomerPhone { get; set; }
        [Required(ErrorMessage = "Please enter a delivery address.")]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }
        [Required(ErrorMessage = "Please choose Buy or Rent.")]
        [Display(Name = "Buy or Rent")]
        public string OrderType { get; set; }
        [Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10.")]
        public int Quantity { get; set; }
        [Range(1, 30, ErrorMessage = "Rental days must be between 1 and 30.")]
        [Display(Name = "Number of Rental Days")]
        public int RentalDays { get; set; }
        [Display(Name = "Include beaded accessories & headgear (+R150 per item)")]
        public bool IncludeAccessories { get; set; }
    }
}
