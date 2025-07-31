using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: /Admin/Category
        public IActionResult Index()
        {
            // TODO: Lấy danh sách danh mục từ database
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Danh mục 1", Description = "Mô tả danh mục 1", IsActive = true },
                new Category { Id = 2, Name = "Danh mục 2", Description = "Mô tả danh mục 2", IsActive = true },
                new Category { Id = 3, Name = "Danh mục 3", Description = "Mô tả danh mục 3", IsActive = false }
            };
            
            return View(categories);
        }
        
        // GET: /Admin/Category/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: /Admin/Category/Create
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                // TODO: Lưu danh mục mới vào database
                TempData["Message"] = "Thêm danh mục thành công!";
                return RedirectToAction("Index");
            }
            
            return View(category);
        }
        
        // GET: /Admin/Category/Edit/5
        public IActionResult Edit(int id)
        {
            // TODO: Lấy danh mục từ database
            var category = new Category
            {
                Id = id,
                Name = "Danh mục " + id,
                Description = "Mô tả danh mục " + id,
                IsActive = true
            };
            
            if (category == null)
            {
                return NotFound();
            }
            
            return View(category);
        }
        
        // POST: /Admin/Category/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                // TODO: Cập nhật danh mục trong database
                TempData["Message"] = "Cập nhật danh mục thành công!";
                return RedirectToAction("Index");
            }
            
            return View(category);
        }
        
        // POST: /Admin/Category/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // TODO: Kiểm tra danh mục có sản phẩm không
            // Nếu có sản phẩm thì không cho xóa
            // Nếu không có sản phẩm thì xóa danh mục
            
            TempData["Message"] = "Xóa danh mục thành công!";
            return RedirectToAction("Index");
        }
        
        // POST: /Admin/Category/ToggleStatus/5
        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            // TODO: Thay đổi trạng thái active/inactive của danh mục
            TempData["Message"] = "Cập nhật trạng thái thành công!";
            return RedirectToAction("Index");
        }
    }
} 