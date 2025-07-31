using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        
        public int ProductId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalPrice { get; set; }
        
        // Navigation properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
} 