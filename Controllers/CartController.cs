using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class CartController : Controller
    {
        // GET: /Cart
        public IActionResult Index()
        {
            // TODO: Lấy giỏ hàng của user hiện tại từ database
            var cartItems = new List<CartItem>
            {
                new CartItem 
                { 
                    Id = 1, 
                    ProductId = 1, 
                    Quantity = 2,
                    Product = new Product { Id = 1, Name = "Sản phẩm 1", Price = 100000, ImageUrl = "/images/product1.jpg" }
                },
                new CartItem 
                { 
                    Id = 2, 
                    ProductId = 2, 
                    Quantity = 1,
                    Product = new Product { Id = 2, Name = "Sản phẩm 2", Price = 200000, ImageUrl = "/images/product2.jpg" }
                }
            };
            
            return View(cartItems);
        }
        
        // POST: /Cart/AddToCart/5
        [HttpPost]
        public IActionResult AddToCart(int id, int quantity = 1)
        {
            // TODO: Thêm sản phẩm vào giỏ hàng
            // Kiểm tra sản phẩm tồn tại
            // Kiểm tra số lượng tồn kho
            // Thêm hoặc cập nhật cart item
            
            TempData["Message"] = "Đã thêm sản phẩm vào giỏ hàng!";
            return RedirectToAction("Index");
        }
        
        // POST: /Cart/Remove/5
        [HttpPost]
        public IActionResult Remove(int id)
        {
            // TODO: Xóa sản phẩm khỏi giỏ hàng
            TempData["Message"] = "Đã xóa sản phẩm khỏi giỏ hàng!";
            return RedirectToAction("Index");
        }
        
        // POST: /Cart/UpdateQuantity
        [HttpPost]
        public IActionResult UpdateQuantity(int cartItemId, int quantity)
        {
            // TODO: Cập nhật số lượng sản phẩm trong giỏ hàng
            if (quantity <= 0)
            {
                return RedirectToAction("Remove", new { id = cartItemId });
            }
            
            TempData["Message"] = "Đã cập nhật số lượng!";
            return RedirectToAction("Index");
        }
    }
} 