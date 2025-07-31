using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: /Order/Checkout
        public IActionResult Checkout()
        {
            // TODO: Lấy thông tin giỏ hàng và user hiện tại
            var cartItems = new List<CartItem>
            {
                new CartItem 
                { 
                    Id = 1, 
                    ProductId = 1, 
                    Quantity = 2,
                    Product = new Product { Id = 1, Name = "Sản phẩm 1", Price = 100000 }
                }
            };
            
            var order = new Order
            {
                TotalAmount = cartItems.Sum(item => item.Quantity * item.Product.Price)
            };
            
            return View(order);
        }
        
        // POST: /Order/Checkout
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            {
                // TODO: Lưu đơn hàng vào database
                // Tạo Order và OrderDetails
                // Xóa giỏ hàng
                // Gửi email xác nhận
                
                TempData["Message"] = "Đặt hàng thành công!";
                return RedirectToAction("Confirm", new { id = 1 }); // 1 là order ID
            }
            
            return View(order);
        }
        
        // GET: /Order/Confirm/5
        public IActionResult Confirm(int id)
        {
            // TODO: Lấy thông tin đơn hàng từ database
            var order = new Order
            {
                Id = id,
                OrderDate = DateTime.Now,
                TotalAmount = 200000,
                Status = OrderStatus.Pending
            };
            
            return View(order);
        }
        
        // GET: /Order/MyOrders
        public IActionResult MyOrders()
        {
            // TODO: Lấy danh sách đơn hàng của user hiện tại
            var orders = new List<Order>
            {
                new Order { Id = 1, OrderDate = DateTime.Now.AddDays(-5), TotalAmount = 200000, Status = OrderStatus.Delivered },
                new Order { Id = 2, OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 150000, Status = OrderStatus.Shipped },
                new Order { Id = 3, OrderDate = DateTime.Now, TotalAmount = 300000, Status = OrderStatus.Pending }
            };
            
            return View(orders);
        }
        
        // GET: /Order/Details/5
        public IActionResult Details(int id)
        {
            // TODO: Lấy chi tiết đơn hàng từ database
            var order = new Order
            {
                Id = id,
                OrderDate = DateTime.Now.AddDays(-5),
                TotalAmount = 200000,
                Status = OrderStatus.Delivered,
                ShippingAddress = "123 Đường ABC, Quận 1, TP.HCM",
                Phone = "0123456789",
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail 
                    { 
                        ProductId = 1, 
                        Quantity = 2, 
                        UnitPrice = 100000, 
                        TotalPrice = 200000,
                        Product = new Product { Name = "Sản phẩm 1" }
                    }
                }
            };
            
            return View(order);
        }
    }
} 