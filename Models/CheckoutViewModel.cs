using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class CheckoutViewModel
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        public string Notes { get; set; }

        [Required]
        public string PaymentMethod { get; set; }
    }
}
