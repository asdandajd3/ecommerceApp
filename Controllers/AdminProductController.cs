using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: /Admin/Product
        public IActionResult Index(string searchTerm, int? categoryId, int page = 1)
        {
            // TODO: Lấy danh sách sản phẩm từ database với filter và pagination
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Sản phẩm 1", Price = 100000, StockQuantity = 50, CategoryId = 1, IsActive = true },
                new Product { Id = 2, Name = "Sản phẩm 2", Price = 200000, StockQuantity = 30, CategoryId = 1, IsActive = true },
                new Product { Id = 3, Name = "Sản phẩm 3", Price = 150000, StockQuantity = 25, CategoryId = 2, IsActive = true }
            };
            
            ViewBag.SearchTerm = searchTerm;
            ViewBag.CategoryId = categoryId;
            ViewBag.CurrentPage = page;
            
            return View(products);
        }
        
        // GET: /Admin/Product/Create
        public IActionResult Create()
        {
            // TODO: Lấy danh sách categories cho dropdown
            ViewBag.Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Danh mục 1" },
                new Category { Id = 2, Name = "Danh mục 2" }
            };
            
            return View();
        }
        
        // POST: /Admin/Product/Create
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // TODO: Lưu sản phẩm mới vào database
                TempData["Message"] = "Thêm sản phẩm thành công!";
                return RedirectToAction("Index");
            }
            
            // Reload categories for dropdown
            ViewBag.Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Danh mục 1" },
                new Category { Id = 2, Name = "Danh mục 2" }
            };
            
            return View(product);
        }
        
        // GET: /Admin/Product/Edit/5
        public IActionResult Edit(int id)
        {
            // TODO: Lấy sản phẩm từ database
            var product = new Product
            {
                Id = id,
                Name = "Sản phẩm " + id,
                Price = 100000 + (id * 50000),
                Description = "Mô tả sản phẩm " + id,
                StockQuantity = 50,
                CategoryId = 1,
                IsActive = true
            };
            
            if (product == null)
            {
                return NotFound();
            }
            
            ViewBag.Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Danh mục 1" },
                new Category { Id = 2, Name = "Danh mục 2" }
            };
            
            return View(product);
        }
        
        // POST: /Admin/Product/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                // TODO: Cập nhật sản phẩm trong database
                TempData["Message"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction("Index");
            }
            
            ViewBag.Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Danh mục 1" },
                new Category { Id = 2, Name = "Danh mục 2" }
            };
            
            return View(product);
        }
        
        // POST: /Admin/Product/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // TODO: Xóa sản phẩm khỏi database
            TempData["Message"] = "Xóa sản phẩm thành công!";
            return RedirectToAction("Index");
        }
        
        // POST: /Admin/Product/ToggleStatus/5
        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            // TODO: Thay đổi trạng thái active/inactive của sản phẩm
            TempData["Message"] = "Cập nhật trạng thái thành công!";
            return RedirectToAction("Index");
        }
    }
} 