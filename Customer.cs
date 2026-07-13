using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace IsintuWebsite.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter the customer's name.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter a delivery address.")]
        public string Address { get; set; }

        // A customer can place many orders over time
        public virtual ICollection<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}
