using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: /Admin/Dashboard
        public IActionResult Dashboard()
        {
            // TODO: Lấy thống kê từ database
            var stats = new DashboardStats
            {
                TotalUsers = 150,
                TotalProducts = 45,
                TotalOrders = 89,
                TotalRevenue = 15000000,
                RecentOrders = new List<Order>
                {
                    new Order { Id = 1, OrderDate = DateTime.Now.AddHours(-2), TotalAmount = 500000, Status = OrderStatus.Pending },
                    new Order { Id = 2, OrderDate = DateTime.Now.AddHours(-4), TotalAmount = 750000, Status = OrderStatus.Confirmed },
                    new Order { Id = 3, OrderDate = DateTime.Now.AddHours(-6), TotalAmount = 300000, Status = OrderStatus.Shipped }
                },
                TopProducts = new List<Product>
                {
                    new Product { Id = 1, Name = "Sản phẩm 1", StockQuantity = 50 },
                    new Product { Id = 2, Name = "Sản phẩm 2", StockQuantity = 30 },
                    new Product { Id = 3, Name = "Sản phẩm 3", StockQuantity = 25 }
                }
            };
            
            return View(stats);
        }
        
        // GET: /Admin
        public IActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }
    }
    
    public class DashboardStats
    {
        public int TotalUsers { get; set; }
        public int TotalProducts { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public List<Order> RecentOrders { get; set; }
        public List<Product> TopProducts { get; set; }
    }
} 