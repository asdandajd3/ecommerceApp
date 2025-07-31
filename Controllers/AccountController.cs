using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }
        
        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Xác thực đăng nhập
                // Kiểm tra username/password trong database
                // Tạo session/cookie
                
                TempData["Message"] = "Đăng nhập thành công!";
                return RedirectToAction("Index", "Home");
            }
            
            return View(model);
        }
        
        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }
        
        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Đăng ký tài khoản mới
                // Kiểm tra username/email đã tồn tại
                // Mã hóa password
                // Lưu user vào database
                // Tạo giỏ hàng cho user
                
                TempData["Message"] = "Đăng ký thành công! Vui lòng đăng nhập.";
                return RedirectToAction("Login");
            }
            
            return View(model);
        }
        
        // POST: /Account/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            // TODO: Xóa session/cookie
            TempData["Message"] = "Đã đăng xuất!";
            return RedirectToAction("Index", "Home");
        }
        
        // GET: /Account/Profile
        public IActionResult Profile()
        {
            // TODO: Lấy thông tin user hiện tại
            var user = new User
            {
                Id = 1,
                Username = "user1",
                Email = "user1@example.com",
                FullName = "Nguyễn Văn A",
                Address = "123 Đường ABC, Quận 1, TP.HCM",
                Phone = "0123456789"
            };
            
            return View(user);
        }
        
        // POST: /Account/Profile
        [HttpPost]
        public IActionResult Profile(User user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Cập nhật thông tin user
                TempData["Message"] = "Cập nhật thông tin thành công!";
                return RedirectToAction("Profile");
            }
            
            return View(user);
        }
    }
    
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
    
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [StringLength(100)]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(100)]
        public string FullName { get; set; }
        
        [StringLength(200)]
        public string Address { get; set; }
        
        [StringLength(20)]
        public string Phone { get; set; }
    }
} 