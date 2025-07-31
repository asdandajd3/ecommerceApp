using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        // Navigation properties
        public virtual User User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
    
    public class CartItem
    {
        public int Id { get; set; }
        
        public int CartId { get; set; }
        
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        
        public DateTime AddedAt { get; set; } = DateTime.Now;
        
        // Navigation properties
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
} 