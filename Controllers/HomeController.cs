using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: /
        public IActionResult Index()
        {
            // TODO: Lấy danh sách sản phẩm nổi bật từ database
            var featuredProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Sản phẩm 1", Price = 100000, ImageUrl = "/images/product1.jpg" },
                new Product { Id = 2, Name = "Sản phẩm 2", Price = 200000, ImageUrl = "/images/product2.jpg" },
                new Product { Id = 3, Name = "Sản phẩm 3", Price = 150000, ImageUrl = "/images/product3.jpg" }
            };
            
            return View(featuredProducts);
        }
        
        public IActionResult About()
        {
            return View();
        }
        
        public IActionResult Contact()
        {
            return View();
        }
    }
} 