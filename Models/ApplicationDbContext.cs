using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Điện tử", Description = "Sản phẩm điện tử", IsActive = true, CreatedAt = DateTime.Now },
                new Category { Id = 2, Name = "Thời trang", Description = "Quần áo, giày dép", IsActive = true, CreatedAt = DateTime.Now },
                new Category { Id = 3, Name = "Sách", Description = "Sách vở, tài liệu", IsActive = true, CreatedAt = DateTime.Now }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 15", Description = "Điện thoại iPhone 15", Price = 25000000, StockQuantity = 50, CategoryId = 1, IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Product { Id = 2, Name = "Samsung Galaxy S24", Description = "Điện thoại Samsung Galaxy S24", Price = 20000000, StockQuantity = 30, CategoryId = 1, IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Product { Id = 3, Name = "Áo thun nam", Description = "Áo thun nam chất liệu cotton", Price = 150000, StockQuantity = 100, CategoryId = 2, IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            // Seed Admin User
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Email = "admin@example.com", Password = "admin123", FullName = "Administrator", IsAdmin = true, IsActive = true, CreatedAt = DateTime.Now }
            );
        }
    }
} 