using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string ShippingAddress { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalAmount { get; set; }
        
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        [StringLength(20)]
        public string PaymentMethod { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        
        public DateTime? ShippedDate { get; set; }
        
        public DateTime? DeliveredDate { get; set; }
        
        // Navigation properties
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
    
    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Shipped,
        Delivered,
        Cancelled
    }
} 