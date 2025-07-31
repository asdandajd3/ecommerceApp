using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class AdminOrderController : Controller
    {
        // GET: /Admin/Order
        public IActionResult Index(OrderStatus? status, string searchTerm, int page = 1)
        {
            // TODO: Lấy danh sách đơn hàng từ database với filter và pagination
            var orders = new List<Order>
            {
                new Order 
                { 
                    Id = 1, 
                    OrderDate = DateTime.Now.AddDays(-5), 
                    TotalAmount = 500000, 
                    Status = OrderStatus.Pending,
                    User = new User { Username = "user1", FullName = "Nguyễn Văn A" }
                },
                new Order 
                { 
                    Id = 2, 
                    OrderDate = DateTime.Now.AddDays(-3), 
                    TotalAmount = 750000, 
                    Status = OrderStatus.Confirmed,
                    User = new User { Username = "user2", FullName = "Trần Thị B" }
                },
                new Order 
                { 
                    Id = 3, 
                    OrderDate = DateTime.Now.AddDays(-1), 
                    TotalAmount = 300000, 
                    Status = OrderStatus.Shipped,
                    User = new User { Username = "user3", FullName = "Lê Văn C" }
                }
            };
            
            ViewBag.Status = status;
            ViewBag.SearchTerm = searchTerm;
            ViewBag.CurrentPage = page;
            
            return View(orders);
        }
        
        // GET: /Admin/Order/Details/5
        public IActionResult Details(int id)
        {
            // TODO: Lấy chi tiết đơn hàng từ database
            var order = new Order
            {
                Id = id,
                OrderDate = DateTime.Now.AddDays(-5),
                TotalAmount = 500000,
                Status = OrderStatus.Pending,
                ShippingAddress = "123 Đường ABC, Quận 1, TP.HCM",
                Phone = "0123456789",
                Notes = "Ghi chú đơn hàng",
                User = new User { Username = "user1", FullName = "Nguyễn Văn A", Email = "user1@example.com" },
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail 
                    { 
                        ProductId = 1, 
                        Quantity = 2, 
                        UnitPrice = 200000, 
                        TotalPrice = 400000,
                        Product = new Product { Name = "Sản phẩm 1", ImageUrl = "/images/product1.jpg" }
                    },
                    new OrderDetail 
                    { 
                        ProductId = 2, 
                        Quantity = 1, 
                        UnitPrice = 100000, 
                        TotalPrice = 100000,
                        Product = new Product { Name = "Sản phẩm 2", ImageUrl = "/images/product2.jpg" }
                    }
                }
            };
            
            if (order == null)
            {
                return NotFound();
            }
            
            return View(order);
        }
        
        // POST: /Admin/Order/UpdateStatus/5
        [HttpPost]
        public IActionResult UpdateStatus(int id, OrderStatus status)
        {
            // TODO: Cập nhật trạng thái đơn hàng
            // Gửi email thông báo cho khách hàng
            
            TempData["Message"] = "Cập nhật trạng thái đơn hàng thành công!";
            return RedirectToAction("Details", new { id = id });
        }
        
        // POST: /Admin/Order/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // TODO: Xóa đơn hàng (chỉ cho phép xóa đơn hàng đã hủy)
            TempData["Message"] = "Xóa đơn hàng thành công!";
            return RedirectToAction("Index");
        }
        
        // GET: /Admin/Order/Export
        public IActionResult Export(OrderStatus? status, DateTime? fromDate, DateTime? toDate)
        {
            // TODO: Xuất danh sách đơn hàng ra file Excel/CSV
            TempData["Message"] = "Xuất file thành công!";
            return RedirectToAction("Index");
        }
    }
} 