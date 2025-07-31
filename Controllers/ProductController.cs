using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Product/List
        public IActionResult List(int? categoryId, string searchTerm, int page = 1)
        {
            // TODO: Lấy danh sách sản phẩm từ database với filter và pagination
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Sản phẩm 1", Price = 100000, Description = "Mô tả sản phẩm 1", ImageUrl = "/images/product1.jpg" },
                new Product { Id = 2, Name = "Sản phẩm 2", Price = 200000, Description = "Mô tả sản phẩm 2", ImageUrl = "/images/product2.jpg" },
                new Product { Id = 3, Name = "Sản phẩm 3", Price = 150000, Description = "Mô tả sản phẩm 3", ImageUrl = "/images/product3.jpg" }
            };
            
            ViewBag.CategoryId = categoryId;
            ViewBag.SearchTerm = searchTerm;
            ViewBag.CurrentPage = page;
            
            return View(products);
        }
        
        // GET: /Product/Details/5
        public IActionResult Details(int id)
        {
            // TODO: Lấy chi tiết sản phẩm từ database
            var product = new Product 
            { 
                Id = id, 
                Name = "Sản phẩm " + id, 
                Price = 100000 + (id * 50000), 
                Description = "Mô tả chi tiết sản phẩm " + id,
                StockQuantity = 10,
                ImageUrl = $"/images/product{id}.jpg"
            };
            
            if (product == null)
            {
                return NotFound();
            }
            
            return View(product);
        }
    }
} 