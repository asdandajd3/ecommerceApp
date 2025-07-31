using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class AdminUserController : Controller
    {
        // GET: /Admin/User
        public IActionResult Index(string searchTerm, bool? isActive, int page = 1)
        {
            // TODO: Lấy danh sách người dùng từ database với filter và pagination
            var users = new List<User>
            {
                new User 
                { 
                    Id = 1, 
                    Username = "user1", 
                    Email = "user1@example.com", 
                    FullName = "Nguyễn Văn A",
                    IsActive = true,
                    IsAdmin = false,
                    CreatedAt = DateTime.Now.AddDays(-30)
                },
                new User 
                { 
                    Id = 2, 
                    Username = "user2", 
                    Email = "user2@example.com", 
                    FullName = "Trần Thị B",
                    IsActive = true,
                    IsAdmin = false,
                    CreatedAt = DateTime.Now.AddDays(-25)
                },
                new User 
                { 
                    Id = 3, 
                    Username = "admin", 
                    Email = "admin@example.com", 
                    FullName = "Admin",
                    IsActive = true,
                    IsAdmin = true,
                    CreatedAt = DateTime.Now.AddDays(-60)
                }
            };
            
            ViewBag.SearchTerm = searchTerm;
            ViewBag.IsActive = isActive;
            ViewBag.CurrentPage = page;
            
            return View(users);
        }
        
        // GET: /Admin/User/Details/5
        public IActionResult Details(int id)
        {
            // TODO: Lấy chi tiết người dùng từ database
            var user = new User
            {
                Id = id,
                Username = "user" + id,
                Email = "user" + id + "@example.com",
                FullName = "Nguyễn Văn " + (char)('A' + id - 1),
                Address = "123 Đường ABC, Quận 1, TP.HCM",
                Phone = "0123456789",
                IsActive = true,
                IsAdmin = false,
                CreatedAt = DateTime.Now.AddDays(-30)
            };
            
            if (user == null)
            {
                return NotFound();
            }
            
            return View(user);
        }
        
        // POST: /Admin/User/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // TODO: Kiểm tra user có đơn hàng không
            // Nếu có đơn hàng thì không cho xóa
            // Nếu không có đơn hàng thì xóa user
            
            TempData["Message"] = "Xóa người dùng thành công!";
            return RedirectToAction("Index");
        }
        
        // POST: /Admin/User/ToggleStatus/5
        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            // TODO: Thay đổi trạng thái active/inactive của user
            TempData["Message"] = "Cập nhật trạng thái thành công!";
            return RedirectToAction("Index");
        }
        
        // POST: /Admin/User/ToggleAdmin/5
        [HttpPost]
        public IActionResult ToggleAdmin(int id)
        {
            // TODO: Thay đổi quyền admin của user
            TempData["Message"] = "Cập nhật quyền admin thành công!";
            return RedirectToAction("Index");
        }
        
        // GET: /Admin/User/ResetPassword/5
        public IActionResult ResetPassword(int id)
        {
            // TODO: Reset password cho user và gửi email
            TempData["Message"] = "Reset password thành công! Email đã được gửi.";
            return RedirectToAction("Index");
        }
    }
} 